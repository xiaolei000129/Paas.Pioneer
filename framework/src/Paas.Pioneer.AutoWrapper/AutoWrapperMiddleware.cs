using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Paas.Pioneer.AutoWrapper.Base;

namespace Paas.Pioneer.AutoWrapper
{
    internal class AutoWrapperMiddleware : WrapperBase
    {
        private readonly AutoWrapperMembers _awm;
        public AutoWrapperMiddleware(RequestDelegate next,
            AutoWrapperOptions options,
            ILogger<AutoWrapperMiddleware> logger,
            IResponseOutput<object> _result
            ) : base(next, options, logger)
        {
            var jsonSettings = Helpers.JSONHelper.GetJSONSettings(options.IgnoreNullValue, options.ReferenceLoopHandling, options.UseCamelCaseNamingStrategy);
            _awm = new AutoWrapperMembers(options, logger, jsonSettings, _result);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await InvokeAsyncBase(context, _awm);
        }
    }
}
