using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.information.Domain.Shared
{
    [DependsOn(
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    public class informationsDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            informationsGlobalFeatureConfigurator.Configure();
            informationsModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<informationsDomainSharedModule>();
            });
        }
    }
}
