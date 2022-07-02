using Paas.Pioneer.User.Application;
using Paas.Pioneer.User.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.User.Application.Tests
{
    [DependsOn(
        typeof(UsersApplicationModule),
        typeof(UsersDomainTestModule)
        )]
    public class UsersApplicationTestModule : AbpModule
    {

    }
}