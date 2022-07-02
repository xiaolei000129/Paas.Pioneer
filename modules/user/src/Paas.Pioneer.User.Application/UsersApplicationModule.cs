using Paas.Pioneer.User.Application.Contracts;
using Paas.Pioneer.User.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.User.Application
{
    [DependsOn(
        typeof(UsersDomainModule),
        typeof(UsersApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class UsersApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<UsersApplicationModule>();
            });
        }
    }
}
