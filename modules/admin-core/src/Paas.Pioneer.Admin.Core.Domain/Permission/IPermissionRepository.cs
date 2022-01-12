using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Permission
{
    public interface IPermissionRepository : IRepository<Ad_PermissionEntity, Guid>, IBaseExtensionRepository<Ad_PermissionEntity>
    {
        /// <summary>
        /// 获取权限点
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetPermissionsCodeListAsync(Guid? userId, bool isTenant);

        /// <summary>
        /// 获取权限菜单
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<IEnumerable<Ad_PermissionEntity>> GetPermissionsMenuAsync(Guid? userId, bool isTenant);
    }
}
