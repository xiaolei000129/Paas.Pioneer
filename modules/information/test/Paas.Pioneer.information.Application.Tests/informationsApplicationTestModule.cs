using Paas.Pioneer.Information.Application;
using Paas.Pioneer.Information.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Information.Application.Tests
{
    [DependsOn(
        typeof(InformationsApplicationModule),
        typeof(InformationsDomainTestModule)
        )]
    public class InformationsApplicationTestModule : AbpModule
    {

    }
}