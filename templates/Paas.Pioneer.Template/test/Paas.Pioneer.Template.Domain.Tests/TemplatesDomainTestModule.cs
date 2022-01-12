using Paas.Pioneer.Template.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Template.Domain.Tests
{
    [DependsOn(
        typeof(TemplatesEntityFrameworkCoreTestModule)
        )]
    public class TemplatesDomainTestModule : AbpModule
    {

    }
}