using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Admin.Core.Application.Contracts;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.HttpApi.Client
{
    [DependsOn(
        typeof(AdminsApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiClientModule)
    )]
    public class AdminsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AdminsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
