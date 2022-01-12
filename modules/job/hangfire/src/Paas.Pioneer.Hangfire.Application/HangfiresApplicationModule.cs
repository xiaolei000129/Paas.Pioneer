using Paas.Pioneer.Admin.Core.Application;
using Paas.Pioneer.Hangfire.Application.Contracts;
using Paas.Pioneer.Hangfire.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Hangfire.Application
{
    [DependsOn(
        typeof(HangfiresDomainModule),
        typeof(HangfiresApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AdminsApplicationModule)
        )]
    public class HangfiresApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<HangfiresApplicationModule>();
            });
        }
    }
}
