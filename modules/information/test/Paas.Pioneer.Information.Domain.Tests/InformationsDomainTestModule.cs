using Paas.Pioneer.Information.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Information.Domain.Tests
{
    [DependsOn(
        typeof(InformationsEntityFrameworkCoreTestModule)
        )]
    public class InformationsDomainTestModule : AbpModule
    {

    }
}