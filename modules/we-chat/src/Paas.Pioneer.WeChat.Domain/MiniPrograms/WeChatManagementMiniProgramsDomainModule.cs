using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.WeChat.Domain.MiniPrograms
{
    [DependsOn(
        typeof(WeChatManagementMiniProgramsDomainSharedModule)
    )]
    public class WeChatManagementMiniProgramsDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
