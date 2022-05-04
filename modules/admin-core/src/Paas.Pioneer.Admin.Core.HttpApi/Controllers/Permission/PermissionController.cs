using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Output;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 权限管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class PermissionController : AbpControllerBase
    {
        private readonly IPermissionService _permissionService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permissionService"></param>
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// 查询权限列表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PermissionListOutput>> GetList(string key, DateTime? start, DateTime? end)
        {
            return await _permissionService.GetListAsync(key, start, end);
        }

        /// <summary>
        /// 查询单条分组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PermissionGetGroupOutput> GetGroup(Guid id)
        {
            return await _permissionService.GetGroupAsync(id);
        }

        /// <summary>
        /// 查询单条菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PermissionGetMenuOutput> GetMenu(Guid id)
        {
            return await _permissionService.GetMenuAsync(id);
        }

        /// <summary>
        /// 查询单条接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PermissionGetApiOutput> GetApi(Guid id)
        {
            return await _permissionService.GetApiAsync(id);
        }

        /// <summary>
        /// 查询单条权限点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PermissionGetDotOutput> GetDot(Guid id)
        {
            return await _permissionService.GetDotAsync(id);
        }

        /// <summary>
        /// 查询角色权限-权限列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetPermissionList()
        {
            return await _permissionService.GetPermissionListAsync();
        }

        /// <summary>
        /// 查询角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Guid>> GetRolePermissionList(Guid roleId)
        {
            return await _permissionService.GetRolePermissionListAsync(roleId);
        }

        /// <summary>
        /// 查询租户权限
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Guid>> GetTenantPermissionList(Guid tenantId)
        {
            return await _permissionService.GetTenantPermissionListAsync(tenantId);
        }

        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddGroup([FromBody] PermissionAddGroupInput input)
        {
            await _permissionService.AddGroupAsync(input);
        }

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddMenu([FromBody] PermissionAddMenuInput input)
        {
            await _permissionService.AddMenuAsync(input);
        }

        /// <summary>
        /// 新增接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddApi([FromBody] PermissionAddApiInput input)
        {
            await _permissionService.AddApiAsync(input);
        }

        /// <summary>
        /// 新增权限点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddDot([FromBody] PermissionAddDotInput input)
        {
            await _permissionService.AddDotAsync(input);
        }

        /// <summary>
        /// 修改分组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateGroup([FromBody] PermissionUpdateGroupInput input)
        {
            await _permissionService.UpdateGroupAsync(input);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateMenu([FromBody] PermissionUpdateMenuInput input)
        {
            await _permissionService.UpdateMenuAsync(input);
        }

        /// <summary>
        /// 修改接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateApi([FromBody] PermissionUpdateApiInput input)
        {
            await _permissionService.UpdateApiAsync(input);
        }

        /// <summary>
        /// 修改权限点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateDot([FromBody] PermissionUpdateDotInput input)
        {
            await _permissionService.UpdateDotAsync(input);
        }

        /// <summary>
        /// 彻底删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _permissionService.DeleteAsync(id);
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Assign([FromBody] PermissionAssignInput input)
        {
            await _permissionService.AssignAsync(input);
        }

        /// <summary>
        /// 保存租户权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task SaveTenantPermissions([FromBody] PermissionSaveTenantPermissionsInput input)
        {
            await _permissionService.SaveTenantPermissionsAsync(input);
        }
    }
}