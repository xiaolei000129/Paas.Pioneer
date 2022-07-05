using Paas.Pioneer.User.Application.Contracts;
using Paas.Pioneer.User.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.User.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UsersEntityFrameworkCoreModule),
    typeof(UsersApplicationContractsModule)
    )]
public class UsersDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
       
    }
}
