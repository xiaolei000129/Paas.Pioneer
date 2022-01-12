using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Paas.Pioneer.Template.Domain.Data;

namespace Paas.Pioneer.Template.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
	{
		private readonly IHostApplicationLifetime _hostApplicationLifetime;
		private readonly IConfiguration _configuration;

		public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
		{
			_hostApplicationLifetime = hostApplicationLifetime;
			_configuration = configuration;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			using (var application = AbpApplicationFactory.Create<TemplatesDbMigratorModule>(options =>
			{
				options.Services.ReplaceConfiguration(_configuration);
				options.UseAutofac();
				options.Services.AddLogging(c => c.AddNLog("NLog.config"));
			}))
			{
				application.Initialize();

				await application
					.ServiceProvider
					.GetRequiredService<TemplatesDbMigrationService>()
					.MigrateAsync();

				application.Shutdown();

				_hostApplicationLifetime.StopApplication();
			}
		}

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
	}
}
