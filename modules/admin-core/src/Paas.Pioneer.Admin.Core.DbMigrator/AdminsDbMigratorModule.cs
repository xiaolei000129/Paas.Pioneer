using Paas.Pioneer.Admin.Core.Application.Contracts;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Admin.Core.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AdminsEntityFrameworkCoreModule),
        typeof(AdminsApplicationContractsModule)
        )]
    public class AdminsDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
