using Paas.Pioneer.Information.Application.Contracts;
using Paas.Pioneer.Information.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Information.Application
{
    [DependsOn(
        typeof(InformationsDomainModule),
        typeof(InformationsApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class InformationsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<InformationsApplicationModule>();
            });
        }
    }
}
