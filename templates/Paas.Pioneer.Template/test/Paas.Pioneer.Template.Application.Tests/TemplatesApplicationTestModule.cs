using Paas.Pioneer.Template.Application;
using Paas.Pioneer.Template.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Template.Application.Tests
{
    [DependsOn(
        typeof(TemplatesApplicationModule),
        typeof(TemplatesDomainTestModule)
        )]
    public class TemplatesApplicationTestModule : AbpModule
    {

    }
}