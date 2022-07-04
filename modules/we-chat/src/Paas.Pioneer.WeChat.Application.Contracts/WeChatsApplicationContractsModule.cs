using Paas.Pioneer.WeChat.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.WeChat.Application.Contracts
{
    [DependsOn(
        typeof(WeChatsDomainSharedModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
        )]
    public class WeChatsApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            WeChatsDtoExtensions.Configure();
        }
    }
}
