using Paas.Pioneer.information.Application.Contracts;
using Paas.Pioneer.information.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.information.DbMigrator
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
