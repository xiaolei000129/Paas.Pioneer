using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Paas.Pioneer.AutoWrapper.Extensions;
using Paas.Pioneer.AutoWrapper.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Paas.Pioneer.AutoWrapper
{
    internal class AutoWrapperMembers
    {
        private readonly AutoWrapperOptions _options;
        private readonly ILogger<AutoWrapperMiddleware> _logger;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly IResponseOutput<object> _result;
        public AutoWrapperMembers(AutoWrapperOptions options,
                                    ILogger<AutoWrapperMiddleware> logger,
                                    JsonSerializerSettings jsonSettings,
                                    IResponseOutput<object> result)
        {
            _options = options;
            _logger = logger;
            _jsonSettings = jsonSettings;
            _result = result;
        }

        public async Task<string> ReadResponseBodyStreamAsync(Stream bodyStream)
        {
            bodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(bodyStream).ReadToEndAsync();
            bodyStream.Seek(0, SeekOrigin.Begin);

            var (IsEncoded, ParsedText) = responseBody.VerifyBodyContent();

            return IsEncoded ? ParsedText : responseBody;
        }

        public async Task RevertResponseBodyStreamAsync(Stream bodyStream, Stream orginalBodyStream)
        {
            bodyStream.Seek(0, SeekOrigin.Begin);
            await bodyStream.CopyToAsync(orginalBodyStream);
        }

        public async Task HandleSuccessfulRequestAsync(HttpContext context, string body, int httpStatusCode)
        {
            object bodyObj = body;
            if (body.ToString().IsValidJson())
            {
                bodyObj = JsonConvert.DeserializeObject<object>(body);
            }
            var bodyText = ConvertToJSONString(_result.Succees(bodyObj));
            await WriteFormattedResponseToHttpContextAsync(context, httpStatusCode, bodyText);
        }

        public async Task HandleErrorRequestAsync(HttpContext context, string errorBody, int httpStatusCode)
        {
            var bodyText = ConvertToJSONString(_result.Error(errorBody));
            await WriteFormattedResponseToHttpContextAsync(context, httpStatusCode, bodyText);
        }

        public async Task HandleNotApiRequestAsync(HttpContext context)
        {
            string configErrorText = ResponseMessage.NotApiOnly;
            context.Response.ContentLength = configErrorText != null ? Encoding.UTF8.GetByteCount(configErrorText) : 0;
            await context.Response.WriteAsync(configErrorText);
        }

        public bool IsSwagger(HttpContext context, string swaggerPath)
        {
            return context.Request.Path.StartsWithSegments(new PathString(swaggerPath));
        }

        public bool IsExclude(HttpContext context, IEnumerable<AutoWrapperExcludePath> excludePaths)
        {
            if (excludePaths == null || excludePaths.Count() == 0)
            {
                return false;
            }

            return excludePaths.Any(x =>
            {
                switch (x.ExcludeMode)
                {
                    default:
                    case ExcludeMode.Strict:
                        return context.Request.Path.Value == x.Path;
                    case ExcludeMode.StartWith:
                        return context.Request.Path.StartsWithSegments(new PathString(x.Path));
                    case ExcludeMode.Regex:
                        Regex regExclude = new Regex(x.Path);
                        return regExclude.IsMatch(context.Request.Path.Value);
                }
            });
        }

        public bool IsApi(HttpContext context)
        {
            if (_options.IsApiOnly
                && !context.Request.Path.Value.Contains(".js")
                && !context.Request.Path.Value.Contains(".css")
                && !context.Request.Path.Value.Contains(".html"))
                return true;

            return context.Request.Path.StartsWithSegments(new PathString(_options.WrapWhenApiPathStartsWith));
        }

        public async Task WrapIgnoreAsync(HttpContext context, object body)
        {
            var bodyText = body.ToString();
            context.Response.ContentLength = bodyText != null ? Encoding.UTF8.GetByteCount(bodyText) : 0;
            await context.Response.WriteAsync(bodyText);
        }

        public bool IsRequestSuccessful(int statusCode)
        {
            return statusCode >= 200 && statusCode < 400;
        }

        #region Private Members

        private async Task WriteFormattedResponseToHttpContextAsync(HttpContext context, int httpStatusCode, string jsonString)
        {
            context.Response.StatusCode = httpStatusCode;
            context.Response.ContentType = TypeIdentifier.JSONHttpContentMediaType;
            context.Response.ContentLength = jsonString != null ? Encoding.UTF8.GetByteCount(jsonString) : 0;
            await context.Response.WriteAsync(jsonString);
        }

        private string ConvertToJSONString(object rawJSON) => JsonConvert.SerializeObject(rawJSON, _jsonSettings);
        #endregion
    }

}
