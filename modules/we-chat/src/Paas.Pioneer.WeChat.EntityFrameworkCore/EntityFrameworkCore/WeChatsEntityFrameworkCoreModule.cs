using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.WeChat.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.EntityFrameworkCore
{
    [DependsOn(
        typeof(WeChatsDomainModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule)
        )]
    public class WeChatsEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            WeChatsEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<WeChatsDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also WeChatsMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}
