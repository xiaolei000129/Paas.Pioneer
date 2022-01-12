using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.User
{
    public interface IUserRepository : IRepository<Ad_UserEntity, Guid>, IBaseExtensionRepository<Ad_UserEntity>
    {
        Task<IEnumerable<UserRoleInfo>> GetUserRoleInfoById(Guid id);

        /// <summary>
        /// 通过TenantId获取UserIdList
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        Task<IEnumerable<Guid>> GetUserIdListByTenantIdAsync(Guid TenantId);

        Task<IEnumerable<UserRoleInfo>> GetUserRoleInfoById(IEnumerable<Guid> userIds);
    }
}
