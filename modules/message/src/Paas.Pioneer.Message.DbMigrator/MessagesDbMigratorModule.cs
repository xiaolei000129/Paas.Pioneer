using Paas.Pioneer.Message.Application.Contracts;
using Paas.Pioneer.Message.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Message.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MessagesEntityFrameworkCoreModule),
        typeof(MessagesApplicationContractsModule)
        )]
    public class MessagesDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}
