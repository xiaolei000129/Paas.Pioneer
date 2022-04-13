using Paas.Pioneer.information.Application.Contracts;
using Paas.Pioneer.information.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.information.Application
{
    [DependsOn(
        typeof(informationsDomainModule),
        typeof(informationsApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class informationsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<informationsApplicationModule>();
            });
        }
    }
}
