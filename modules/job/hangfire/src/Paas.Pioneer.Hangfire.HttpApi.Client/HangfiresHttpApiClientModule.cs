using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Hangfire.Application.Contracts;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Hangfire.HttpApi.Client
{
    [DependsOn(
        typeof(HangfiresApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiClientModule)
    )]
    public class HangfiresHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HangfiresApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
