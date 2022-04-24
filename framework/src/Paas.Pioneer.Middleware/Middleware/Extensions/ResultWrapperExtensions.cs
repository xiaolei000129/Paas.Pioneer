using Microsoft.AspNetCore.Builder;

namespace Paas.Pioneer.Middleware.Middleware.ResultWrapper
{
    public static class ResultWrapperExtensions
    {
        public static IApplicationBuilder UseResultWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResultWrapperMiddleware>();
        }
    }
}
