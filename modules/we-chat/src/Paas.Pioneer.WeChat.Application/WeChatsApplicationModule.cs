using Paas.Pioneer.WeChat.Application.Contracts;
using Paas.Pioneer.WeChat.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.WeChat.Application
{
    [DependsOn(
        typeof(WeChatsDomainModule),
        typeof(WeChatsApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class WeChatsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<WeChatsApplicationModule>();
            });
        }
    }
}
