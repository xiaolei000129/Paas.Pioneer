using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Template.Application.Contracts;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Template.HttpApi.Client
{
    [DependsOn(
        typeof(TemplatesApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiClientModule)
    )]
    public class TemplatesHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(TemplatesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
