using Microsoft.AspNetCore.Builder;

namespace Paas.Pioneer.Middleware.Middleware.Extensions
{
	public static class LoggerExtensions
	{
		/// <summary>
		/// 全局日志中间件
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<LoggerMiddleware>();
		}
	}
}
