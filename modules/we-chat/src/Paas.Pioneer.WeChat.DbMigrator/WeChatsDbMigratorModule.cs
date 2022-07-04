using Paas.Pioneer.WeChat.Application.Contracts;
using Paas.Pioneer.WeChat.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.WeChat.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(WeChatsEntityFrameworkCoreModule),
        typeof(WeChatsApplicationContractsModule)
        )]
    public class WeChatsDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}
