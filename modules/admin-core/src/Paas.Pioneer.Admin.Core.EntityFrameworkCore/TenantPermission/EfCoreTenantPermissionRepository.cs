using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.TenantPermission;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.TenantPermission
{
    public class EfCoreTenantPermissionRepository : BaseExtensionsRepository<Ad_TenantPermissionEntity>, ITenantPermissionRepository
    {
        public EfCoreTenantPermissionRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 通过TenantId获取PermissionIdList
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> GetPermissionIdListByTenantIdAsync(Guid? TenantId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .Where(p => p.TenantId == TenantId)
                .Select(p => p.PermissionId).ToListAsync();
        }
    }
}
