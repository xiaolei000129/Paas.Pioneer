using Paas.Pioneer.information.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.information.Domain.Tests
{
    [DependsOn(
        typeof(InformationsEntityFrameworkCoreTestModule)
        )]
    public class InformationsDomainTestModule : AbpModule
    {

    }
}