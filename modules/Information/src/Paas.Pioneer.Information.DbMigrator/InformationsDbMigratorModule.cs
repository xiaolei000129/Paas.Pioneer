using Paas.Pioneer.Information.Application.Contracts;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Information.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(InformationsEntityFrameworkCoreModule),
        typeof(InformationsApplicationContractsModule)
        )]
    public class InformationsDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}
