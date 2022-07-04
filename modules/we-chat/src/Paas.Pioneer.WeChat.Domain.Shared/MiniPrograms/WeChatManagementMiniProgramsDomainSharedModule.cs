using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;
using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms.Localization;
using Paas.Pioneer.WeChat.Domain.Shared.Common.Localization;

namespace Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class WeChatManagementMiniProgramsDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<WeChatManagementMiniProgramsDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MiniProgramsResource>("en")
                    .AddBaseTypes(typeof(CommonResource))
                    .AddVirtualJson("/EasyAbp/WeChatManagement/MiniPrograms/Localization");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("EasyAbp.WeChatManagement.MiniPrograms", typeof(MiniProgramsResource));
            });
        }
    }
}
