using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.TenantManagement;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Tenant
{
    /// <summary>
    /// 租户管理
    /// </summary>
    public class TenantService : ApplicationService, ITenantService
    {
        private readonly Domain.Tenant.ITenantRepository _tenantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IPermissionRepository _permissionRepository;
        public TenantService(Domain.Tenant.ITenantRepository tenantRepository,
             IUserRepository userRepository,
             IRoleRepository roleRepository,
             IUserRoleRepository userRoleRepository,
             IRolePermissionRepository rolePermissionRepository,
             IPermissionRepository permissionRepository)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<IResponseOutput> AddAsync(TenantAddInput input)
        {
            if (await _tenantRepository.AnyAsync(x => x.Name == input.Name.Trim()))
            {
                throw new BusinessException("租户已存在！");
            }
            var entity = ObjectMapper.Map<TenantAddInput, Volo.Abp.TenantManagement.Tenant>(input);
            var tenant = await _tenantRepository.InsertAsync(entity, true);
            var tenantId = tenant.Id;

            //添加用户
            var pwd = MD5Encrypt.Encrypt32("111111");

            var user = new Ad_UserEntity
            {
                TenantId = tenantId,
                UserName = input.ExtraProperties["Phone"]?.ToString(),
                NickName = input.ExtraProperties["RealName"]?.ToString(),
                Password = pwd,
                Enabled = true,
            };
            await _userRepository.InsertAsync(user);

            //添加角色
            var role = new Ad_RoleEntity
            {
                TenantId = tenantId,
                Code = Domain.Shared.Const.TenantConsts.TenantRoleDefaultCode,
                Name = Domain.Shared.Const.TenantConsts.TenantRoleDefaultName,
                Enabled = true
            };
            await _roleRepository.InsertAsync(role);

            //添加用户角色
            var userRole = new Ad_UserRoleEntity() { UserId = user.Id, RoleId = role.Id };
            await _userRoleRepository.InsertAsync(userRole);
            //更新租户用户和角色
            tenant = await _tenantRepository.GetAsync(tenantId);
            tenant.SetProperty("UserId", user.Id);
            tenant.SetProperty("RoleId", role.Id);
            await _tenantRepository.UpdateAsync(tenant, true);
            return ResponseOutput.Succees("操作成功");
        }

        public async Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            //删除用户
            await _userRepository.DeleteAsync(a => ids.Contains(a.TenantId.Value));

            //删除角色
            await _roleRepository.DeleteAsync(a => ids.Contains(a.TenantId.Value));

            //删除租户
            await _tenantRepository.DeleteAsync(a => ids.Contains(a.Id));

            return ResponseOutput.Succees("操作成功");
        }

        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            var roleIds = await _roleRepository.GetListAsync(expression: x => x.TenantId == id, selector: x => x.Id, order: null);
            var userIds = await _userRepository.GetListAsync(expression: x => x.TenantId == id, selector: x => x.Id, order: null);
            //删除角色权限
            await _rolePermissionRepository.HardDeleteAsync(a => roleIds.Contains(a.RoleId));

            //删除用户角色
            await _userRoleRepository.HardDeleteAsync(a => userIds.Contains(a.UserId));

            //删除用户
            await _userRepository.HardDeleteAsync(a => a.TenantId == id);

            //删除角色
            await _roleRepository.HardDeleteAsync(a => a.TenantId == id);

            //删除租户
            await _tenantRepository.HardDeleteAsync(a => a.Id == id);

            return ResponseOutput.Succees();
        }

        public async Task<ResponseOutput<TenantGetOutput>> GetAsync(Guid id)
        {
            var result = ObjectMapper.Map<Volo.Abp.TenantManagement.Tenant, TenantGetOutput>(await _tenantRepository.GetAsync(predicate: x => x.Id == id));
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<Page<GetTenantPageListOutput>>> GetPageListAsync(PageInput<GetTenantsInput> input)
        {
            var tenantQueryable = await _tenantRepository.GetQueryableAsync();
            var key = input.Filter?.Filter;
            var query = tenantQueryable.WhereIf(!key.IsNullOrEmpty(), x => x.Name.Contains(key));
            var tenantPageList = await query.OrderByDescending(x => x.CreationTime).Page(input.CurrentPage, input.PageSize).ToListAsync();
            var resultPageData = ObjectMapper.Map<List<Volo.Abp.TenantManagement.Tenant>, List<GetTenantPageListOutput>>(tenantPageList);
            return ResponseOutput.Succees(new Page<GetTenantPageListOutput>
            {
                Total = await query.CountAsync(),
                List = resultPageData
            });
        }

        public async Task<IResponseOutput> SoftDeleteAsync(Guid id)
        {
            //删除用户
            await _userRepository.DeleteAsync(a => a.TenantId == id);

            //删除角色
            await _roleRepository.DeleteAsync(a => a.TenantId == id);

            //删除租户
            await _tenantRepository.DeleteAsync(x => x.Id == id);

            return ResponseOutput.Succees("删除成功");
        }

        public async Task<IResponseOutput> UpdateAsync(TenantUpdateInput input)
        {
            var entity = await _tenantRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new BusinessException("租户不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _tenantRepository.UpdateAsync(entity);
            return ResponseOutput.Succees();
        }
    }
}
