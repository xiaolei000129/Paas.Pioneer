using Paas.Pioneer.Message.Application.Contracts;
using Paas.Pioneer.Message.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Message.Application
{
    [DependsOn(
        typeof(MessagesDomainModule),
        typeof(MessagesApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class MessagesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MessagesApplicationModule>();
            });
        }
    }
}
