using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.UserRole
{
    public interface IUserRoleRepository : IRepository<Ad_UserRoleEntity, Guid>, IBaseExtensionRepository<Ad_UserRoleEntity>
    {
        /// <summary>
        /// 通过RoleId获取UserIdList
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        Task<IEnumerable<Guid>> GetUserIdListByRoleIdAsync(Guid roleId);

    }
}
