using Paas.Pioneer.Admin.Core.Domain.Shared;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore
{
    public static class AdminsEfCoreEntityExtensionMappings
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            AdminsGlobalFeatureConfigurator.Configure();
            AdminsModuleExtensionConfigurator.Configure();

            OneTimeRunner.Run(() =>
            {
                // 编码
                ObjectExtensionManager.Instance
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, string>(
                    "Code",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(50);
                    }
                )
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, string>(
                    "RealName",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(50);
                    }
                )
                /// 手机号码
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, string>(
                    "Phone",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(20);
                    }
                )
                /// 邮箱
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, string>(
                    "Email",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(50);
                    }
                )
                // 授权角色
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, Guid?>(
                        "UserId",
                        (entityBuilder, propertyBuilder) =>
                        {
                            propertyBuilder.HasMaxLength(36);
                        }
                    )
                // 授权用户
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, Guid?>(
                    "RoleId",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(36);
                    }
                )
                // 租户类型
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, ETenantType?>(
                    "TenantType",
                    (entityBuilder, propertyBuilder) =>
                    {

                    }
                )
                /// 启用
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, bool?>(
                    "Enabled",
                    (entityBuilder, propertyBuilder) =>
                    {
                    }
                )
                /// 说明
                .MapEfCoreProperty<Volo.Abp.TenantManagement.Tenant, string>(
                    "Description",
                    (entityBuilder, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(500);
                    }
                );
                /* You can configure extra properties for the
                 * entities defined in the modules used by your application.
                 *
                 * This class can be used to map these extra properties to table fields in the database.
                 *
                 * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
                 * USE AdminsModuleExtensionConfigurator CLASS (in the Domain.Shared project)
                 * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
                 *
                 * Example: Map a property to a table field:

                     ObjectExtensionManager.Instance
                         .MapEfCoreProperty<IdentityUser, string>(
                             "MyProperty",
                             (entityBuilder, propertyBuilder) =>
                             {
                                 propertyBuilder.HasMaxLength(128);
                             }
                         );

                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
                 */
            });


        }
    }
}
