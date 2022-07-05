using Paas.Pioneer.Redis;
using Paas.Pioneer.User.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Paas.Pioneer.User.Domain.Shared
{
    [DependsOn(
        typeof(AbpTenantManagementDomainSharedModule),
        typeof(RedisModule)
        )]
    public class UsersDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            UsersGlobalFeatureConfigurator.Configure();
            UsersModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<UsersDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MiniProgramsResource>("en")
                    .AddBaseTypes(typeof(MiniProgramsResource))
                    .AddVirtualJson("/Localization");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Paas.Pioneer.User.Domain.Shared.Localization", typeof(MiniProgramsResource));
            });
        }
    }
}
