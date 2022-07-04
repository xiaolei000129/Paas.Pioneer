using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Paas.Pioneer.WeChat.Domain.Shared;
using Paas.Pioneer.WeChat.Domain.Shared.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.WeChat.Domain
{
    [DependsOn(
        typeof(WeChatsDomainSharedModule),
        typeof(AbpTenantManagementDomainModule)
    )]
    public class WeChatsDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }
    }
}
