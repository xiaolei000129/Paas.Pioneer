using Paas.Pioneer.Redis;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.Template.Domain.Shared
{
    [DependsOn(
        typeof(AbpTenantManagementDomainSharedModule),
        typeof(RedisModule)
        )]
    public class TemplatesDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            TemplatesGlobalFeatureConfigurator.Configure();
            TemplatesModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<TemplatesDomainSharedModule>();
            });
        }
    }
}
