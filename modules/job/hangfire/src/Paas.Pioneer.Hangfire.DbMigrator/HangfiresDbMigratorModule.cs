using Paas.Pioneer.Hangfire.Application.Contracts;
using Paas.Pioneer.Hangfire.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Hangfire.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HangfiresEntityFrameworkCoreModule),
        typeof(HangfiresApplicationContractsModule)
        )]
    public class HangfiresDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}
