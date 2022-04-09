using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.Middleware.Middleware.Logger;
using System.Linq;
using Paas.Pioneer.Domain.Shared.Helpers;
using Newtonsoft.Json;

namespace Paas.Pioneer.Middleware
{
    /// <summary>
    /// 请求日志记录中间件
    /// </summary>
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _logger;
        private string requestBody = string.Empty;
        private string query = string.Empty;
        private string token = string.Empty;
        private string url = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LoggerMiddleware(RequestDelegate next,
            ILogger<LoggerMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        /// 全局日志中间件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var cur = DateTime.Now;
            if (request.Method.Equals("GET") || request.Method.Equals("POST"))
            {
                token = context.Request.Headers["Token"];
                url = context.Request.Host + context.Request.Path;
                try
                {
                    var log = new LoggerModel();
                    if (request.Method.Equals("GET"))
                    {
                        log = await GetQueryAsync(context, url);
                    }
                    else if (new[] { "POST" }.Contains(request.Method))
                    {
                        //设置请求重复读取
                        context.Request.EnableBuffering();
                        log = await GetRequestBodyAsync(context, request, url);
                    }
                    // 响应完成记录时间和存入日志
                    context.Response.OnCompleted(() =>
                    {
                        log.TotalSeconds = (DateTime.Now - cur).TotalSeconds;
                        _logger.LogInformation(JsonConvert.SerializeObject(log));
                        return Task.CompletedTask;
                    });
                }
                catch (Exception ex)
                {
                    var log = new LoggerModel()
                    {
                        Id = context.Connection.Id,
                        Url = url,
                        Token = token,
                        Body = requestBody,
                        Method = request.Method,
                        Query = query,
                        StatusCode = HttpStatusCode.InternalServerError,
                        TotalSeconds = (DateTime.Now - cur).TotalSeconds
                    };
                    _logger.LogError(JsonConvert.SerializeObject(log), ex);
                }
            }
            else
            {
                await _next(context);
            }
        }

        /// <summary>
        /// 获取requestBody方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="request"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<LoggerModel> GetRequestBodyAsync(HttpContext context, HttpRequest request, string url)
        {
            var sr = new StreamReader(request.Body);
            requestBody = await sr.ReadToEndAsync();
            if ("application/x-www-form-urlencoded".Equals(request.ContentType))
            {
                requestBody = UnicodeHelper.UnicodeToString(requestBody);
            }
            request.Body.Seek(0, SeekOrigin.Begin);
            return await GetResponse(context, url);
        }

        /// <summary>
        /// 获取query方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<LoggerModel> GetQueryAsync(HttpContext context, string url)
        {
            query = UnicodeHelper.UnicodeToString(context.Request.QueryString.Value);
            return await GetResponse(context, url);
        }

        /// <summary>
        /// 获取响应内容
        /// </summary>
        /// <param name="context"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<LoggerModel> GetResponse(HttpContext context, string url)
        {
            // 先保存原来的流
            // 原因：context.Response.Body读完之后，要会返回值再写回去（不然前端context.Response.Body为空）
            var originalBodyStream = context.Response.Body;
            var log = new LoggerModel();
            //所以我们创建一个自己的流
            using (var responseBody = new MemoryStream())
            {
                //设置读写流
                context.Response.Body = responseBody;
                // 进入请求
                await _next(context);
                // 读写流信息
                var response = await GetResponseStream(context.Response);
                // 将信息反写到原来的流中（因为流已经被我们改变了，只有之前保存的流是原始流）
                await responseBody.CopyToAsync(originalBodyStream);
                log = new LoggerModel()
                {
                    Id = context.Connection.Id,
                    Url = url,
                    StatusCode = (HttpStatusCode)context.Response.StatusCode,
                    Body = requestBody,
                    Query = query,
                    Method = context.Request.Method,
                    ResponseContent = response,
                    Token = token
                };
            }
            return log;
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
