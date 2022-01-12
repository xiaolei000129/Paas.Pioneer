using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.RolePermission
{
    public interface IRolePermissionRepository : IRepository<Ad_RolePermissionEntity, Guid>, IBaseExtensionRepository<Ad_RolePermissionEntity>
    {
        /// <summary>
        /// 通过RoleId获取PermissionIdList
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        Task<List<Guid>> GetPermissionIdListByRoleIdAsync(Guid RoleId);
    }
}
