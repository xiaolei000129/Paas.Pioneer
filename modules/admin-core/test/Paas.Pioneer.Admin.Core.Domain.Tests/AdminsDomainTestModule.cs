using Paas.Pioneer.Admin.Core.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Admin.Core.Domain.Tests
{
    [DependsOn(
        typeof(AdminsEntityFrameworkCoreTestModule)
        )]
    public class AdminsDomainTestModule : AbpModule
    {

    }
}