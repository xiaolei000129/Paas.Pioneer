using Paas.Pioneer.User.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.User.Domain.Tests
{
    [DependsOn(
        typeof(UsersEntityFrameworkCoreTestModule)
        )]
    public class UsersDomainTestModule : AbpModule
    {

    }
}