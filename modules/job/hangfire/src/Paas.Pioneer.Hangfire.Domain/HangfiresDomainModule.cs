using Paas.Pioneer.Admin.Core.Domain;
using Paas.Pioneer.Hangfire.Domain.Shared;
using Paas.Pioneer.Hangfire.Domain.Shared.MultiTenancy;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Hangfire.Domain
{
    [DependsOn(
        typeof(HangfiresDomainSharedModule),
        typeof(AbpTenantManagementDomainModule),
        typeof(AdminsDomainModule),
        typeof(AbpBackgroundJobsDomainModule)
    )]
    public class HangfiresDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }
    }
}
