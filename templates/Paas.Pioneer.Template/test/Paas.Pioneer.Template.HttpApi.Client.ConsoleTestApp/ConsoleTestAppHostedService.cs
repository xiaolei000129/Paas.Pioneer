using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace Paas.Pioneer.Template.HttpApi.Client.ConsoleTestApp
{
	public class ConsoleTestAppHostedService : IHostedService
	{
		private readonly IConfiguration _configuration;

		public ConsoleTestAppHostedService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			using (var application = AbpApplicationFactory.Create<TemplatesConsoleApiClientModule>(options =>
			{
				options.Services.ReplaceConfiguration(_configuration);
			}))
			{
				application.Initialize();

				var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();

				application.Shutdown();
				await Task.Delay(1);
			}
		}

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
	}
}
