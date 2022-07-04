using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms.Localization;
using Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms;

namespace Paas.Pioneer.WeChat.HttpApi.Controllers.MiniPrograms
{
    [DependsOn(
        typeof(WeChatManagementMiniProgramsApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule)
    )]
    public class WeChatManagementMiniProgramsHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(WeChatManagementMiniProgramsHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MiniProgramsResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
