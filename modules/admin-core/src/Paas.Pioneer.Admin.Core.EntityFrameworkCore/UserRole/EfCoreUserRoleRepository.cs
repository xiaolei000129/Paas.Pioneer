using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.UserRole
{
    public class EfCoreUserRoleRepository : BaseExtensionsRepository<Ad_UserRoleEntity>, IUserRoleRepository
    {
        public EfCoreUserRoleRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 通过RoleId获取UserIdList
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> GetUserIdListByRoleIdAsync(Guid roleId)
        {
            var dbContext = await GetDbContextAsync();
            var userIdList = await dbContext.Set<Ad_UserRoleEntity>()
                .Where(p => p.RoleId == roleId)
                .Select(p => p.UserId).ToListAsync();
            return userIdList;
        }
    }
}
