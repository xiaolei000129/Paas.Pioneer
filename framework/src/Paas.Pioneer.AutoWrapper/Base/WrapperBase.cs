using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Paas.Pioneer.AutoWrapper.Extensions;
using Paas.Pioneer.AutoWrapper.Attributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Linq;
using Volo.Abp.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Paas.Pioneer.AutoWrapper.Base
{
    internal abstract class WrapperBase
    {
        private readonly RequestDelegate _next;
        private readonly AutoWrapperOptions _options;
        private readonly ILogger<AutoWrapperMiddleware> _logger;
        public WrapperBase(RequestDelegate next,
                          AutoWrapperOptions options,
                          ILogger<AutoWrapperMiddleware> logger)
        {
            _next = next;
            _options = options;
            _logger = logger;
        }

        public virtual async Task InvokeAsyncBase(HttpContext context, AutoWrapperMembers awm)
        {
            if (awm.IsSwagger(context, _options.SwaggerPath) || !awm.IsApi(context) || awm.IsExclude(context, _options.ExcludePaths))
            {
                await _next(context);
                return;
            }

            var originalResponseBodyStream = context.Response.Body;
            bool isRequestOk = false;

            using var memoryStream = new MemoryStream();

            try
            {
                context.Response.Body = memoryStream;
                await _next.Invoke(context);

                if (context.Response.HasStarted)
                {
                    LogResponseHasStartedError();
                    return;
                }

                var endpoint = context.GetEndpoint();

                if (endpoint?.Metadata?.GetMetadata<NoAutoWrapperAttribute>() is object)
                {
                    await awm.RevertResponseBodyStreamAsync(memoryStream, originalResponseBodyStream);
                    return;
                }

                //获取Action的返回类型
                var controllerActionDescriptor = endpoint?.Metadata?.GetMetadata<ControllerActionDescriptor>();
                if (controllerActionDescriptor == null)
                {
                    await awm.RevertResponseBodyStreamAsync(memoryStream, originalResponseBodyStream);
                    return;
                }

                //泛型的特殊处理
                var returnType = controllerActionDescriptor.MethodInfo.ReturnType;
                if (returnType == typeof(Task) || returnType == typeof(Task<>) || returnType == typeof(ValueTask<>) || returnType.GetGenericArguments().Any())
                {
                    returnType = returnType.GetGenericArguments().FirstOrDefault();
                }

                //如果终结点已经是ResponseOutput<T>则不进行包装处理
                if (returnType != null && (returnType == typeof(IResponseOutput) || returnType == typeof(ResponseOutput) || returnType == typeof(IResponseOutput<>) || returnType == typeof(ResponseOutput<>)))
                {
                    await awm.RevertResponseBodyStreamAsync(memoryStream, originalResponseBodyStream);
                    return;
                }

                var bodyAsText = await awm.ReadResponseBodyStreamAsync(memoryStream);
                context.Response.Body = originalResponseBodyStream;

                UpdateResponseStatusCode(context);

                // 判断是否为业务异常
                if (context.Response.StatusCode == Status403Forbidden && context.Response.Headers.ContainsKey(AbpHttpConsts.AbpErrorFormat) && context.Response.Headers[AbpHttpConsts.AbpErrorFormat] == "true")
                {
                    context.Response.StatusCode = Status200OK;
                    var errorBody = JObject.Parse(bodyAsText).SelectToken("error.code")?.ToString();
                    if (errorBody == null)
                    {
                        errorBody = JObject.Parse(bodyAsText).SelectToken("error.message")?.ToString();
                    }
                    await awm.HandleErrorRequestAsync(context, errorBody, context.Response.StatusCode);
                    return;
                }

                // 模型验证错误
                if (context.Response.StatusCode == Status400BadRequest)
                {
                    context.Response.StatusCode = Status200OK;
                    var errorBody = JObject.Parse(bodyAsText)?.
                        SelectToken("errors")?.
                        Last?.FirstOrDefault()?.
                        FirstOrDefault()?.
                        ToString();
                    await awm.HandleErrorRequestAsync(context, errorBody, context.Response.StatusCode);
                    return;
                }

                if (context.Response.StatusCode != Status304NotModified || context.Response.StatusCode != Status204NoContent)
                {
                    if (!_options.IsApiOnly
                        && bodyAsText.IsHtml()
                        && !_options.BypassHTMLValidation
                        && context.Response.StatusCode == Status200OK)
                    {
                        context.Response.StatusCode = Status404NotFound;
                    }

                    if (!context.Request.Path.StartsWithSegments(new PathString(_options.WrapWhenApiPathStartsWith))
                        && bodyAsText.IsHtml()
                        && !_options.BypassHTMLValidation
                        && context.Response.StatusCode == Status200OK)
                    {
                        if (memoryStream.Length > 0)
                        {
                            await awm.HandleNotApiRequestAsync(context);
                        }
                        return;
                    }

                    isRequestOk = awm.IsRequestSuccessful(context.Response.StatusCode);
                    if (isRequestOk)
                    {
                        await awm.HandleSuccessfulRequestAsync(context, bodyAsText, context.Response.StatusCode);
                    }
                }

            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {

            }
        }

        private void UpdateResponseStatusCode(HttpContext context)
        {
            // 过滤跨域
            if (string.Compare(context.Request.Method, "OPTIONS") == 0)
            {
                return;
            }
            if (context.Response.StatusCode == Status204NoContent)
            {
                context.Response.StatusCode = Status200OK;
            }
        }

        private void LogResponseHasStartedError()
        {
            _logger.Log(LogLevel.Warning, "The response has already started, the AutoWrapper middleware will not be executed.");
        }
    }

}
