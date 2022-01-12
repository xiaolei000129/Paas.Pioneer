using Paas.Pioneer.Admin.Core.Application.Contracts;
using Paas.Pioneer.Admin.Core.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Application
{
    [DependsOn(
        typeof(AdminsDomainModule),
        typeof(AdminsApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class AdminsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AdminsApplicationModule>();
            });
        }
    }
}
