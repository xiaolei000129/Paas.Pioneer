using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.TenantPermission
{
    public interface ITenantPermissionRepository : IRepository<Ad_TenantPermissionEntity, Guid>, IBaseExtensionRepository<Ad_TenantPermissionEntity>
    {
        // <summary>
        /// 通过TenantId获取PermissionIdList
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        Task<IEnumerable<Guid>> GetPermissionIdListByTenantIdAsync(Guid?TenantId);
    }
}
