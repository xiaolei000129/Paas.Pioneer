using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Paas.Pioneer.Domain.Shared.Configs;
using System.IO;

namespace Paas.Pioneer.Domain.Shared.ApplicationBuilderExtensions
{
	/// <summary>
	/// 静态资源文件拓展
	/// </summary>
	public static class UploadConfigExtensions
	{
		private static void UseFileUploadConfig(IApplicationBuilder app, FileUploadConfig config)
		{
			if (!Directory.Exists(config.UploadPath))
			{
				Directory.CreateDirectory(config.UploadPath);
			}

			app.UseStaticFiles(new StaticFileOptions()
			{
				RequestPath = config.RequestPath,
				FileProvider = new PhysicalFileProvider(config.UploadPath)
			});
		}

		public static IApplicationBuilder UseUploadConfig(this IApplicationBuilder app)
		{
			var uploadConfig = app.ApplicationServices.GetRequiredService<IOptions<UploadConfig>>();
			UseFileUploadConfig(app, uploadConfig.Value.Avatar);
			UseFileUploadConfig(app, uploadConfig.Value.Document);
			return app;
		}
	}
}
