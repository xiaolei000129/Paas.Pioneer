using Paas.Pioneer.Redis;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.WeChat.Domain.Shared
{
    [DependsOn(
        typeof(AbpTenantManagementDomainSharedModule),
        typeof(RedisModule)
        )]
    public class WeChatsDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            WeChatsGlobalFeatureConfigurator.Configure();
            WeChatsModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<WeChatsDomainSharedModule>();
            });
        }
    }
}
