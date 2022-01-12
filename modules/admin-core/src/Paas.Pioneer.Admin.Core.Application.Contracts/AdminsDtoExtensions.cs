using Paas.Pioneer.Domain.Shared.BaseEnum;
using System;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;

namespace Paas.Pioneer.Admin.Core.Application.Contracts
{
    public static class AdminsDtoExtensions
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                ObjectExtensionManager.Instance
                .AddOrUpdate<TenantDto>(options =>
                {
                    options.AddOrUpdateProperty<string>("code");
                    options.AddOrUpdateProperty<string>("realName");
                    options.AddOrUpdateProperty<string>("phone");
                    options.AddOrUpdateProperty<string>("email");
                    options.AddOrUpdateProperty<Guid?>("userId");
                    options.AddOrUpdateProperty<Guid?>("roleId");
                    options.AddOrUpdateProperty<ETenantType?>("tenantType");
                    options.AddOrUpdateProperty<string>("description");
                    options.AddOrUpdateProperty<DateTime>("CreationTime");
                    options.AddOrUpdateProperty<bool>("enabled");
                }).AddOrUpdate<TenantCreateDto>(options =>
                {
                    options.AddOrUpdateProperty<string>("code");
                    options.AddOrUpdateProperty<string>("realName");
                    options.AddOrUpdateProperty<string>("phone");
                    options.AddOrUpdateProperty<string>("email");
                    options.AddOrUpdateProperty<Guid?>("userId");
                    options.AddOrUpdateProperty<Guid?>("roleId");
                    options.AddOrUpdateProperty<ETenantType?>("tenantType");
                    options.AddOrUpdateProperty<string>("description");
                    options.AddOrUpdateProperty<DateTime>("CreationTime");
                    options.AddOrUpdateProperty<bool>("enabled");
                });
                /* You can add extension properties to DTOs
                 * defined in the depended modules.
                 *
                 * Example:
                 *
                 * ObjectExtensionManager.Instance
                 *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
                 *
                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Object-Extensions
                 */
            });
        }
    }
}