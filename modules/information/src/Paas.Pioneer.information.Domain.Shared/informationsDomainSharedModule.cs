using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.Information.Domain.Shared
{
    [DependsOn(
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    public class InformationsDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            InformationsGlobalFeatureConfigurator.Configure();
            InformationsModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<InformationsDomainSharedModule>();
            });
        }
    }
}
