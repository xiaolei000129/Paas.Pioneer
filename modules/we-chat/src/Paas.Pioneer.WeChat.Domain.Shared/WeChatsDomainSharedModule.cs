using Paas.Pioneer.Redis;
using Paas.Pioneer.WeChat.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.WeChat.Domain.Shared;

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

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<WeChatResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Paas.Pioneer.WeChat.Domain.Shared.Localization", typeof(WeChatResource));
        });
    }
}
