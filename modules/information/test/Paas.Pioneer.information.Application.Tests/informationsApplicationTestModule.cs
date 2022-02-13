using Paas.Pioneer.information.Application;
using Paas.Pioneer.information.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.information.Application.Tests
{
    [DependsOn(
        typeof(informationsApplicationModule),
        typeof(informationsDomainTestModule)
        )]
    public class informationsApplicationTestModule : AbpModule
    {

    }
}