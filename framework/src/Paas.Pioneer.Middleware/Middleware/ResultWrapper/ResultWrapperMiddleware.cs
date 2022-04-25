using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Paas.Pioneer.Middleware.Middleware
{
    public class ResultWrapperMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ResultWrapperMiddleware(RequestDelegate next,
            ILogger<LoggerMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string response = await GetResponseAsync(context);
            //判断是否出现了异常状态码，需要特殊处理
            if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
            {
                return;
            }

            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            if (endpoint == null)
            {
                return;
            }

            if (string.Compare(context.Response.ContentType, "application/json", true) != 0)
            {
                return;
            }

            //判断终结点是否包含NoWrapperAttribute
            NoWrapperAttribute noWrapper = endpoint.Metadata.GetMetadata<NoWrapperAttribute>();
            if (noWrapper != null)
            {
                return;
            }

            //获取Action的返回类型
            var controllerActionDescriptor = context.GetEndpoint()?.Metadata.GetMetadata<ControllerActionDescriptor>();
            if (controllerActionDescriptor == null)
            {
                return;
            }

            //泛型的特殊处理
            var returnType = controllerActionDescriptor.MethodInfo.ReturnType;
            if (returnType.IsGenericType && (returnType.GetGenericTypeDefinition() == typeof(Task<>) || returnType.GetGenericTypeDefinition() == typeof(ValueTask<>)))
            {
                returnType = returnType.GetGenericArguments()[0];
            }

            //如果终结点已经是ResponseOutput<T>则不进行包装处理
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(ResponseOutput<>))
            {
                return;
            }

            ////反序列化得到原始结果
            //var result = JsonConvert.DeserializeObject(response);
            //if (result == null)
            //{
            //    return;
            //}

            //对原始结果进行包装
            var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(ResponseOutput.Succees(response));
            if (bytes == null)
            {
                return;
            }
            // 反写流
            using (var responseBody = new MemoryStream(bytes))
            {
                responseBody.CopyTo(context.Response.Body);
            }
        }

        /// <summary>
        /// 获取响应内容
        /// </summary>
        /// <param name="context"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> GetResponseAsync(HttpContext context)
        {
            // 先保存原来的流
            // 原因：context.Response.Body读完之后，要会返回值再写回去（不然前端context.Response.Body为空）
            var originalBodyStream = context.Response.Body;
            var response = string.Empty;
            //所以我们创建一个自己的流
            using (var responseBody = new MemoryStream())
            {
                //设置读写流
                context.Response.Body = responseBody;
                // 进入请求
                await _next(context);
                // 读写流信息
                response = await GetResponseStream(context.Response);
                // 将信息反写到原来的流中（因为流已经被我们改变了，只有之前保存的流是原始流）
                await responseBody.CopyToAsync(originalBodyStream);
            }
            return response;
        }

        /// <summary>
        /// 获取响应内容流
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task<string> GetResponseStream(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            //读流
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }
    }
}
