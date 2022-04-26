using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.PermissionApi;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey;
using Paas.Pioneer.Admin.Core.Domain.TenantPermission;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Domain.Shared.Auth;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.Application.Permission
{
    public class PermissionService : ApplicationService, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly ITenantPermissionRepository _tenantPermissionRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPermissionApiRepository _permissionApiRepository;
        private readonly IUserRepository _userRepository;
        private readonly RedisAdminKeys _redisAdminKeys;
        private readonly AppConfig _appConfig;

        public PermissionService(
            IOptions<AppConfig> appConfig,
            IPermissionRepository permissionRepository,
            IRoleRepository roleRepository,
            IRolePermissionRepository rolePermissionRepository,
            ITenantPermissionRepository tenantPermissionRepository,
            IUserRoleRepository userRoleRepository,
            IPermissionApiRepository permissionApiRepository,
            IUserRepository userRepository,
            RedisAdminKeys redisAdminKeys
        )
        {
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _tenantPermissionRepository = tenantPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _permissionApiRepository = permissionApiRepository;
            _userRepository = userRepository;
            _redisAdminKeys = redisAdminKeys;
            _appConfig = appConfig.Value;
        }

        public async Task<ResponseOutput<PermissionGetGroupOutput>> GetGroupAsync(Guid id)
        {
            var result = await _permissionRepository.GetAsync(expression: x => x.Id == id, selector: x => new PermissionGetGroupOutput()
            {
                Id = x.Id,
                Hidden = x.Hidden,
                Icon = x.Icon,
                Label = x.Label,
                Opened = x.Opened,
                ParentId = x.ParentId,
                Type = x.Type,
            });
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<PermissionGetMenuOutput>> GetMenuAsync(Guid id)
        {
            var result = await _permissionRepository.GetAsync(expression: x => x.Id == id, selector: x => new PermissionGetMenuOutput()
            {
                Id = x.Id,
                Closable = x.Closable,
                Description = x.Description,
                External = x.External,
                Hidden = x.Hidden,
                Icon = x.Icon,
                Label = x.Label,
                NewWindow = x.NewWindow,
                ParentId = x.ParentId,
                Path = x.Path,
                Type = x.Type,
                ViewId = x.ViewId,
            });
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<PermissionGetApiOutput>> GetApiAsync(Guid id)
        {
            var result = await _permissionRepository.GetAsync(expression: x => x.Id == id, selector: x => new PermissionGetApiOutput()
            {
                Id = x.Id,
                Code = x.Code,
                Description = x.Description,
                Hidden = x.Hidden,
                Icon = x.Icon,
                Label = x.Label,
                ParentId = x.ParentId,
                Type = x.Type,
            });
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<PermissionGetDotOutput>> GetDotAsync(Guid id)
        {
            var output = await _permissionRepository.GetAsync(expression: x => x.Id == id, selector: x => new PermissionGetDotOutput()
            {
                Id = x.Id,
                Code = x.Code,
                Description = x.Description,
                Label = x.Label,
                Icon = x.Icon,
                ParentId = x.ParentId,
                Type = x.Type,
            });
            output.ApiIds = await _permissionApiRepository.GetApiIdListByPermissionIdAsync(id);
            return ResponseOutput.Succees(output);
        }

        public async Task<ResponseOutput<List<PermissionListOutput>>> GetListAsync(string key, DateTime? start, DateTime? end)
        {
            if (end.HasValue)
            {
                end = end.Value.AddDays(1);
            }

            Expression<Func<Ad_PermissionEntity, bool>> predicate = x => true;
            if (!key.IsNullOrEmpty())
            {
                predicate = predicate.And(a => a.Path.Contains(key) || a.Label.Contains(key));
            }
            if (start.HasValue && end.HasValue)
            {
                predicate = predicate.And(a => a.CreationTime.IsBetween(start.Value, end.Value));
            }

            var list = await _permissionRepository.GetResponseOutputListAsync(expression: predicate, selector: x => new PermissionListOutput()
            {
                Id = x.Id,
                Description = x.Description,
                Enabled = x.Enabled,
                Hidden = x.Hidden,
                Icon = x.Icon,
                Label = x.Label,
                Opened = x.Opened,
                ParentId = x.ParentId,
                Path = x.Path,
                Type = x.Type,
            }, x => x.OrderBy(p => p.ParentId));

            var apis = await _permissionApiRepository.GetListAsync();

            foreach (var item in list.Data)
            {
                item.ApiPaths = string.Join(";", apis.Where(b => b.PermissionId == item.Id).Select(b => b.Id));
            }
            return list;
        }

        public async Task<IResponseOutput> AddGroupAsync(PermissionAddGroupInput input)
        {
            var entity = ObjectMapper.Map<PermissionAddGroupInput, Ad_PermissionEntity>(input);
            await _permissionRepository.InsertAsync(entity);

            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> AddMenuAsync(PermissionAddMenuInput input)
        {
            var entity = ObjectMapper.Map<PermissionAddMenuInput, Ad_PermissionEntity>(input);
            await _permissionRepository.InsertAsync(entity);

            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> AddApiAsync(PermissionAddApiInput input)
        {
            var entity = ObjectMapper.Map<PermissionAddApiInput, Ad_PermissionEntity>(input);
            await _permissionRepository.InsertAsync(entity);
            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> AddDotAsync(PermissionAddDotInput input)
        {
            var entity = ObjectMapper.Map<PermissionAddDotInput, Ad_PermissionEntity>(input);
            var id = (await _permissionRepository.InsertAsync(entity)).Id;

            if (input.ApiIds != null && input.ApiIds.Any())
            {
                var permissionApis = input.ApiIds.Select(a => new Ad_PermissionApiEntity { PermissionId = id, ApiId = a });
                await _permissionApiRepository.InsertManyAsync(permissionApis);
            }

            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> UpdateGroupAsync(PermissionUpdateGroupInput input)
        {

            var entity = await _permissionRepository.GetAsync(input.Id);
            entity = ObjectMapper.Map(input, entity);
            await _permissionRepository.UpdateAsync(entity);

            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> UpdateMenuAsync(PermissionUpdateMenuInput input)
        {
            var entity = await _permissionRepository.GetAsync(input.Id);
            entity = ObjectMapper.Map(input, entity);
            await _permissionRepository.UpdateAsync(entity);

            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> UpdateApiAsync(PermissionUpdateApiInput input)
        {

            var entity = await _permissionRepository.GetAsync(input.Id);
            entity = ObjectMapper.Map(input, entity);
            await _permissionRepository.UpdateAsync(entity);

            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> UpdateDotAsync(PermissionUpdateDotInput input)
        {
            var entity = await _permissionRepository.GetAsync(input.Id);
            if (!(entity?.Id != Guid.Empty))
            {
                return ResponseOutput.Succees("权限点不存在！");
            }

            ObjectMapper.Map(input, entity);
            await _permissionRepository.UpdateAsync(entity);

            await _permissionApiRepository.DeleteAsync(a => a.PermissionId == entity.Id);

            if (input.ApiIds != null && input.ApiIds.Any())
            {
                var permissionApis = input.ApiIds.Select(a => new Ad_PermissionApiEntity { PermissionId = entity.Id, ApiId = a });
                await _permissionApiRepository.InsertManyAsync(permissionApis);
            }
            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            var list = await _permissionRepository.ToListAsync();

            var model = list.FirstOrDefault(a => a.Id == id);

            if (model == null)
            {
                throw new BusinessException("权限点不存在！");
            }

            var permissionData = ObjectMapper.Map<List<Ad_PermissionEntity>, List<PermissionDataOutput>>(list);
            var permissionModel = ObjectMapper.Map<Ad_PermissionEntity, PermissionDataOutput>(model);

            var ids = new List<Guid>();

            ids.Add(model.Id);

            //递归查询所有权限点
            AddPermission(permissionData, permissionModel, ids);
            //删除权限关联接口
            await _permissionApiRepository.DeleteAsync(a => ids.Contains(a.PermissionId));

            //删除相关权限
            await _permissionRepository.DeleteAsync(a => ids.Contains(a.Id));

            return ResponseOutput.Succees("删除成功！");
        }

        /// <summary>
        /// 递归遍历子菜单
        /// </summary>
        /// <param name="list">菜单集合</param>
        /// <param name="curPermission">父级菜单</param>
        /// <param name="ids">id容器</param>
        private static void AddPermission(IEnumerable<PermissionDataOutput> list, PermissionDataOutput curPermission, List<Guid> ids)
        {
            var sonPermissions = list.Where(p => p.ParentId.Equals(curPermission.Id));
            curPermission.Childs = sonPermissions;
            foreach (var p in sonPermissions)
            {
                ids.Add(p.Id);
                AddPermission(list, p, ids);
            }
        }

        public async Task<IResponseOutput> AssignAsync(PermissionAssignInput input)
        {
            //分配权限的时候判断角色是否存在
            var exists = await _roleRepository.AnyAsync(a => a.Id == input.RoleId);
            if (!exists)
            {
                return ResponseOutput.Succees("该角色不存在或已被删除！");
            }

            //查询角色权限
            var permissionIds = (await _rolePermissionRepository.GetPermissionIdListByRoleIdAsync(input.RoleId)).ToArray();

            //批量删除权限
            var deleteIds = permissionIds.Where(d => !input.PermissionIds.Contains(d));
            if (deleteIds.Any())
            {
                await _rolePermissionRepository.DeleteAsync(m => m.RoleId == input.RoleId && deleteIds.Contains(m.PermissionId));
            }

            //批量插入权限
            List<Ad_RolePermissionEntity> insertRolePermissions = new List<Ad_RolePermissionEntity>();
            var insertPermissionIds = input.PermissionIds.Where(d => !permissionIds.Contains(d));

            //防止租户非法授权
            if (_appConfig.Tenant && CurrentUser.FindClaim(ClaimAttributes.TenantType).Value == ((int)ETenantType.Tenant).ToString())
            {
                var tenantPermissionIds = await _tenantPermissionRepository.GetPermissionIdListByTenantIdAsync(CurrentTenant.Id);
                insertPermissionIds = insertPermissionIds.Where(d => tenantPermissionIds.Contains(d));
            }

            if (insertPermissionIds.Any())
            {
                insertRolePermissions.AddRange(insertPermissionIds.
                    Select(x => new Ad_RolePermissionEntity()
                    {
                        RoleId = input.RoleId,
                        PermissionId = x,
                    }));
                await _rolePermissionRepository.InsertManyAsync(insertRolePermissions);
            }

            //清除角色下关联的用户权限缓存
            var userIds = await _userRoleRepository.GetUserIdListByRoleIdAsync(input.RoleId);
            if (userIds.Any())
            {
                await RedisHelper.DelAsync(userIds.Select(x => string.Format(_redisAdminKeys.UserPermissions, x)).ToArray());
            }
            return ResponseOutput.Succees("保存成功！");
        }

        public async Task<IResponseOutput> GetPermissionListAsync()
        {
            Expression<Func<Ad_PermissionEntity, bool>> predicate = x => true;

            if (CurrentUser.FindClaim(ClaimAttributes.TenantType).Value == ETenantType.Tenant.ToString())
            {
                var tenantPermissionQueryable = await _tenantPermissionRepository.GetQueryableAsync();
                predicate = predicate.And(a => tenantPermissionQueryable
                .Where(b => b.PermissionId == a.Id &&
                b.TenantId == CurrentUser.TenantId)
                .Any());
            }


            var permissions = await _permissionRepository.GetResponseOutputListAsync(
                expression: predicate,
                selector: a => new { a.Id, a.ParentId, a.Label, a.Type },
                x => x.OrderBy(p => p.Sort));


            var apis = permissions.Data
                .Where(a => a.Type == EPermissionType.Dot)
                .Select(a => new { a.Id, a.ParentId, a.Label });

            var menus = permissions.Data
                .Where(a => (new[] {
                    EPermissionType.Group,
                    EPermissionType.Menu
                }).Contains(a.Type))
                .Select(a => new
                {
                    a.Id,
                    a.ParentId,
                    a.Label,
                    Apis = apis.Where(b => b.ParentId == a.Id).Select(b => new { b.Id, b.Label })
                });
            return ResponseOutput.Succees(menus);
        }

        public async Task<ResponseOutput<List<Guid>>> GetRolePermissionListAsync(Guid roleId)
        {
            var permissionIds = await _rolePermissionRepository.GetPermissionIdListByRoleIdAsync(roleId);
            return ResponseOutput.Succees(permissionIds);
        }

        public async Task<ResponseOutput<IEnumerable<Guid>>> GetTenantPermissionListAsync(Guid tenantId)
        {
            if (CurrentUser.FindClaim(ClaimAttributes.TenantType).Value != ETenantType.Platform.ToString())
            {
                return ResponseOutput.Error<IEnumerable<Guid>>("权限不足");
            }
            using (DataFilter.Disable<IMultiTenant>())
            {
                var permissionIds = await _tenantPermissionRepository.GetPermissionIdListByTenantIdAsync(tenantId);
                return ResponseOutput.Succees(permissionIds);
            }
        }

        public async Task<IResponseOutput> SaveTenantPermissionsAsync(PermissionSaveTenantPermissionsInput input)
        {
            if (CurrentUser.FindClaim(ClaimAttributes.TenantType).Value != ETenantType.Platform.ToString())
            {
                return ResponseOutput.Error<IEnumerable<Guid>>("权限不足");
            }
            using (DataFilter.Disable<IMultiTenant>())
            {
                //查询租户权限
                var permissionIds = await _tenantPermissionRepository.GetPermissionIdListByTenantIdAsync(input.TenantId);

                //批量删除租户权限
                var deleteIds = permissionIds.Where(d => !input.PermissionIds.Contains(d));
                //租户下关联的角色权限
                var roleIds = await _roleRepository.GetListAsync(x => x.TenantId == input.TenantId, selector: x => x.Id);
                if (deleteIds.Any())
                {
                    await _tenantPermissionRepository.DeleteAsync(m => m.TenantId == input.TenantId && deleteIds.Contains(m.PermissionId));
                    foreach (var item in roleIds)
                    {
                        await _rolePermissionRepository.DeleteAsync(a => a.RoleId == item && deleteIds.Contains(a.PermissionId));
                    }
                }

                //批量插入租户权限
                var tenatPermissions = new List<Ad_TenantPermissionEntity>();
                var insertPermissionIds = input.PermissionIds.Where(d => !permissionIds.Contains(d));
                if (insertPermissionIds.Any())
                {
                    tenatPermissions.AddRange(insertPermissionIds.Select(x => new Ad_TenantPermissionEntity()
                    {
                        TenantId = input.TenantId,
                        PermissionId = x,
                    }));
                    await _tenantPermissionRepository.InsertManyAsync(tenatPermissions);
                    // 获取该租户管理员角色赋予权限
                    roleIds = await _roleRepository.GetListAsync(x => x.TenantId == input.TenantId
                    && x.Code == Domain.Shared.Const.TenantConsts.TenantRoleDefaultCode,
                    selector: x => x.Id);
                    foreach (var item in roleIds)
                    {
                        // 添加角色权限
                        var insertRolePermissions = new List<Ad_RolePermissionEntity>();
                        insertRolePermissions.AddRange(
                        insertPermissionIds.Select(x =>
                        new Ad_RolePermissionEntity()
                        {
                            RoleId = item,
                            PermissionId = x,
                        }));
                        await _rolePermissionRepository.InsertManyAsync(insertRolePermissions);
                    }
                }
                //清除租户下所有用户权限缓存
                var userIds = await _userRepository.GetUserIdListByTenantIdAsync(input.TenantId);
                if (userIds.Any())
                {
                    await RedisHelper.DelAsync(userIds.Select(x => string.Format(_redisAdminKeys.UserPermissions, x)).ToArray());
                }
            }
            return ResponseOutput.Succees("操作成功");
        }
    }
}