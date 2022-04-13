using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.information.Application.Contracts;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.information.HttpApi.Client
{
    [DependsOn(
        typeof(informationsApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiClientModule)
    )]
    public class informationsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(informationsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
