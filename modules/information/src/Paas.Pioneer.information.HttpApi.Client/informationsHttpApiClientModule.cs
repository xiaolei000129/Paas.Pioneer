using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.information.Application.Contracts;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.information.HttpApi.Client
{
    [DependsOn(
        typeof(InformationsApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiClientModule)
    )]
    public class InformationsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(InformationsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
