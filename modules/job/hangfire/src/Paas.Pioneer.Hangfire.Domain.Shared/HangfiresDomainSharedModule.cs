using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.Hangfire.Domain.Shared
{
    [DependsOn(
        typeof(AbpTenantManagementDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpBackgroundWorkersHangfireModule)
        )]
    public class HangfiresDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HangfiresGlobalFeatureConfigurator.Configure();
            HangfiresModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HangfiresDomainSharedModule>();
            });
        }
    }
}
