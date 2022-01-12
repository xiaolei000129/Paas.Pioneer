using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class RoleController : AbpControllerBase
    {
        private readonly IRoleService _roleService;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="roleService"></param>
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 查询单条角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<RoleGetOutput>> Get(Guid id)
        {
            return await _roleService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseOutput<Page<RoleListOutput>>> GetPageList([FromBody] PageInput<RoleInput> model)
        {
            return await _roleService.GetPageListAsync(model);
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput>Add([FromBody] RoleAddInput input)
        {
            return await _roleService.AddAsync(input);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput>Update([FromBody] RoleUpdateInput input)
        {
            return await _roleService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput>SoftDelete(Guid id)
        {
            return await _roleService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除角色
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput>BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _roleService.BatchSoftDeleteAsync(ids);
        }
    }
}