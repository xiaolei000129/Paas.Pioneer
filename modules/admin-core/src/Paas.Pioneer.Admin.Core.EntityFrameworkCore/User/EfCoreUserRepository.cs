using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.User
{
    public class EfCoreUserRepository : BaseExtensionsRepository<Ad_UserEntity>, IUserRepository
    {
        private readonly IRepository<Ad_UserRoleEntity, Guid> _userRoleRepository;
        private readonly IRepository<Ad_RoleEntity, Guid> _roleRepository;
        private readonly IRepository<Ad_UserEntity, Guid> _userRepository;
        public EfCoreUserRepository(IDbContextProvider<AdminsDbContext> dbContextProvider,
            IRepository<Ad_UserRoleEntity, Guid> userRoleRepository,
            IRepository<Ad_RoleEntity, Guid> roleRepository,
            IRepository<Ad_UserEntity, Guid> userRepository)
            : base(dbContextProvider)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 通过TenantId获取UserIdList
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> GetUserIdListByTenantIdAsync(Guid TenantId)
        {
            var userQueryable = await _userRepository.GetQueryableAsync();
            var userIdList = await userQueryable.AsNoTracking()
                 .Where(p => p.TenantId == TenantId)
                 .Select(p => p.Id).ToListAsync();
            return userIdList;
        }

        #region 角色信息

        /// <summary>
        /// 角色信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserRoleInfo>> GetUserRoleInfoById(Guid id)
        {
            var userRoleQueryable = await _userRoleRepository.GetQueryableAsync();
            var roleQueryable = await _roleRepository.GetQueryableAsync();

            return await (from ur in userRoleQueryable.AsNoTracking().Where(x => x.UserId == id)
                          join r in roleQueryable.AsNoTracking()
                          on ur.RoleId equals r.Id
                          select new UserRoleInfo()
                          {
                              Id = r.Id,
                              Name = r.Name,
                          }).ToListAsync();
        }

        /// <summary>
        /// 角色信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserRoleInfo>> GetUserRoleInfoById(IEnumerable<Guid> userIds)
        {
            var userRoleQueryable = await _userRoleRepository.GetQueryableAsync();
            var roleQueryable = await _roleRepository.GetQueryableAsync();

            return await (from ur in userRoleQueryable.AsNoTracking().Where(x => userIds.Contains(x.UserId))
                          join r in roleQueryable.AsNoTracking()
                          on ur.RoleId equals r.Id
                          select new UserRoleInfo()
                          {
                              Id = r.Id,
                              Name = r.Name,
                              UserId = ur.UserId
                          }).ToListAsync();
        }
        #endregion



    }
}
