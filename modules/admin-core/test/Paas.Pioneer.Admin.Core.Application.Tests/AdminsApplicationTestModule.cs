using Paas.Pioneer.Admin.Core.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Admin.Core.Application.Tests
{
    [DependsOn(
        typeof(AdminsApplicationModule),
        typeof(AdminsDomainTestModule)
        )]
    public class AdminsApplicationTestModule : AbpModule
    {

    }
}