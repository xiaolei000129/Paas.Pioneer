using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Information.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore
{
    [DependsOn(
        typeof(InformationsDomainModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule)
        )]
    public class InformationsEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            InformationsEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<InformationsDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also InformationsMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}
