using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Admin.Core.Domain.TenantPermission;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Permission
{
    public class EfCorePermissionRepository : BaseExtensionsRepository<Ad_PermissionEntity>, IPermissionRepository
    {
        private readonly IRepository<Ad_PermissionEntity, Guid> _permissionRepository;
        private readonly IRepository<Ad_RolePermissionEntity, Guid> _rolePermissionRepository;
        private readonly IRepository<Ad_UserRoleEntity, Guid> _userRoleRepository;
        private readonly IRepository<Ad_TenantPermissionEntity, Guid> _tenantRoleRepository;
        private readonly ICurrentUser _currentUser;

        public EfCorePermissionRepository(IDbContextProvider<AdminsDbContext> dbContextProvider,
            IRepository<Ad_PermissionEntity, Guid> permissionRepository,
            IRepository<Ad_RolePermissionEntity, Guid> rolePermissionRepository,
            IRepository<Ad_UserRoleEntity, Guid> userRoleRepository,
            IRepository<Ad_TenantPermissionEntity, Guid> tenantRoleRepository,
            ICurrentUser currentUser)
            : base(dbContextProvider)
        {
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _userRoleRepository = userRoleRepository;
            _tenantRoleRepository = tenantRoleRepository;
            _currentUser = currentUser;
        }

        public async Task<IEnumerable<string>> GetPermissionsCodeListAsync(Guid? userId, bool isTenant)
        {
            var permissionQueryable = await _permissionRepository.GetQueryableAsync();
            var userRoleQueryable = await _userRoleRepository.GetQueryableAsync();
            var rolePermissionQueryable = await _rolePermissionRepository.GetQueryableAsync();
            var tenantRoleQueryable = await _tenantRoleRepository.GetQueryableAsync();
            var permissionIds = new List<Guid>();
            if (isTenant)
            {
                permissionIds = await tenantRoleQueryable.Select(x => x.PermissionId).ToListAsync();
            }
            return await (from
                          permission in permissionQueryable
                          .WhereIf(isTenant, x => permissionIds.Contains(x.Id))
                          .Where(a => a.Type == EPermissionType.Dot)
                          join rolePermission in rolePermissionQueryable
                          on permission.Id equals rolePermission.PermissionId
                          join userRole in userRoleQueryable.Where(r => r.UserId == userId)
                          on rolePermission.RoleId equals userRole.RoleId
                          select new
                          {
                              permission.Code
                          })
                         .Select(x => x.Code)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Ad_PermissionEntity>> GetPermissionsMenuAsync(Guid? userId, bool isTenant)
        {
            var permissionQueryable = await _permissionRepository.GetQueryableAsync();
            var userRoleQueryable = await _userRoleRepository.GetQueryableAsync();
            var rolePermissionQueryable = await _rolePermissionRepository.GetQueryableAsync();
            var tenantRoleQueryable = await _tenantRoleRepository.GetQueryableAsync();
            var permissionIds = new List<Guid>();
            if (isTenant)
            {
                permissionIds = await tenantRoleQueryable.Select(x => x.PermissionId).ToListAsync();
            }
            var s = (from permission in permissionQueryable.WhereIf(isTenant, x => permissionIds.Contains(x.Id)).Where(a => new[]
                     {
                            EPermissionType.Group,
                            EPermissionType.Menu
                     }.Contains(a.Type))
                     join rolePermission in rolePermissionQueryable
                     on permission.Id equals rolePermission.PermissionId
                     join userRole in userRoleQueryable.Where(r => r.UserId == userId)
                     on rolePermission.RoleId equals userRole.RoleId
                     select new Ad_PermissionEntity(permission.Id)
                     {
                         Closable = permission.Closable,
                         External = permission.External,
                         Hidden = permission.Hidden,
                         Icon = permission.Icon,
                         Label = permission.Label,
                         NewWindow = permission.NewWindow,
                         Opened = permission.Opened,
                         ParentId = permission.ParentId,
                         Path = permission.Path,
                         ViewId = permission.ViewId
                     }).ToQueryString();
            return await (from permission in permissionQueryable.WhereIf(isTenant, x => permissionIds.Contains(x.Id)).Where(a => new[]
                     {
                            EPermissionType.Group,
                            EPermissionType.Menu
                     }.Contains(a.Type))
                          join rolePermission in rolePermissionQueryable
                          on permission.Id equals rolePermission.PermissionId
                          join userRole in userRoleQueryable.Where(r => r.UserId == userId)
                          on rolePermission.RoleId equals userRole.RoleId
                          select new Ad_PermissionEntity(permission.Id)
                          {
                              Closable = permission.Closable,
                              External = permission.External,
                              Hidden = permission.Hidden,
                              Icon = permission.Icon,
                              Label = permission.Label,
                              NewWindow = permission.NewWindow,
                              Opened = permission.Opened,
                              ParentId = permission.ParentId,
                              Path = permission.Path,
                              ViewId = permission.ViewId
                          }).ToArrayAsync();
        }
    }
}
