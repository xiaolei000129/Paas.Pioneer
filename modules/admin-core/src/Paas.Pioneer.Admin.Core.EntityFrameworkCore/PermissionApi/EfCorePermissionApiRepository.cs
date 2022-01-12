using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.LoginLog;
using Paas.Pioneer.Admin.Core.Domain.PermissionApi;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.PermissionApi
{
    public class EfCorePermissionApiRepository : BaseExtensionsRepository<Ad_PermissionApiEntity>, IPermissionApiRepository
    {
        public EfCorePermissionApiRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 通过PermissionId获取ApiIdList
        /// </summary>
        /// <param name="PermissionId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> GetApiIdListByPermissionIdAsync(Guid PermissionId)
        {
            var dbSet = await GetDbSetAsync();
            var ApiIdList = await dbSet.Where(p => p.PermissionId == PermissionId).Select(p => p.ApiId).ToArrayAsync();
            return ApiIdList;
        }
    }
}
