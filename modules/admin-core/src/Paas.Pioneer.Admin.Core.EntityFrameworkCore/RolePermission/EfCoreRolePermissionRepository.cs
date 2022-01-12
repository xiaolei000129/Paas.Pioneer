using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.RolePermission
{
    public class EfCoreRolePermissionRepository : BaseExtensionsRepository<Ad_RolePermissionEntity>, IRolePermissionRepository
    {
        public EfCoreRolePermissionRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 通过RoleId获取PermissionIdList
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public async Task<List<Guid>> GetPermissionIdListByRoleIdAsync(Guid RoleId)
        {
            var dbContext = await GetDbContextAsync();
            var permissionIdList = await dbContext.Set<Ad_RolePermissionEntity>().Where(x => x.RoleId == RoleId).Select(x => x.PermissionId).ToListAsync();
            return permissionIdList;
        }
    }
}
