using Paas.Pioneer.Hangfire.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Hangfire.Domain.Tests
{
    [DependsOn(
        typeof(HangfiresEntityFrameworkCoreTestModule)
        )]
    public class HangfiresDomainTestModule : AbpModule
    {

    }
}