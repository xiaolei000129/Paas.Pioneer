using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Paas.Pioneer.WeChat.Domain.Shared.Common.Localization;

namespace Paas.Pioneer.WeChat.Domain.Shared.Common
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class WeChatManagementCommonDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<WeChatManagementCommonDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CommonResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/EasyAbp/WeChatManagement/Common/Localization");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("EasyAbp.WeChatManagement.Common", typeof(CommonResource));
            });
        }
    }
}
