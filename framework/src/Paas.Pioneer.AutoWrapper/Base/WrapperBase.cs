using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Paas.Pioneer.AutoWrapper.Extensions;
using Paas.Pioneer.AutoWrapper.Attributes;

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

                var bodyAsText = await awm.ReadResponseBodyStreamAsync(memoryStream);
                context.Response.Body = originalResponseBodyStream;

                if (context.Response.StatusCode != Status304NotModified && context.Response.StatusCode != Status204NoContent)
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

        private void LogResponseHasStartedError()
        {
            _logger.Log(LogLevel.Warning, "The response has already started, the AutoWrapper middleware will not be executed.");
        }
    }

}
