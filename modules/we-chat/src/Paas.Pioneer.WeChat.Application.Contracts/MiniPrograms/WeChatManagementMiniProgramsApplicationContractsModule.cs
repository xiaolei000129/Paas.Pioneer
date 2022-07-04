using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms
{
    [DependsOn(
        typeof(WeChatManagementMiniProgramsDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
    )]
    public class WeChatManagementMiniProgramsApplicationContractsModule : AbpModule
    {

    }
}
