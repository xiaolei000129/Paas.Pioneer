using Paas.Pioneer.Hangfire.Application;
using Paas.Pioneer.Hangfire.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Hangfire.Application.Tests
{
    [DependsOn(
        typeof(HangfiresApplicationModule),
        typeof(HangfiresDomainTestModule)
        )]
    public class HangfiresApplicationTestModule : AbpModule
    {

    }
}