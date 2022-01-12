using Paas.Pioneer.Template.Application.Contracts;
using Paas.Pioneer.Template.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Template.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TemplatesEntityFrameworkCoreModule),
        typeof(TemplatesApplicationContractsModule)
        )]
    public class TemplatesDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}
