using Paas.Pioneer.Template.Application.Contracts;
using Paas.Pioneer.Template.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Template.Application
{
    [DependsOn(
        typeof(TemplatesDomainModule),
        typeof(TemplatesApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class TemplatesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<TemplatesApplicationModule>();
            });
        }
    }
}
