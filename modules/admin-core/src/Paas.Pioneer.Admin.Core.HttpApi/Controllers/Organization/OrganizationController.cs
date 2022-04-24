using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization;
using Volo.Abp.AspNetCore.Mvc;
using System;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Output;
using System.Collections.Generic;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Input;
using Microsoft.AspNetCore.Authorization;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 组织架构
    /// </summary>
    [Route("api/personnel/[controller]/[action]")]
    [Authorize]
    public class OrganizationController : AbpControllerBase
    {
        private readonly IOrganizationService _organizationService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="organizationService"></param>
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        /// <summary>
        /// 查询单条组织架构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<OrganizationGetOutput>> Get(Guid id)
        {
            return await _organizationService.GetAsync(id);
        }

        /// <summary>
        /// 查询组织架构列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseOutput<List<OrganizationListOutput>>> GetList(string key)
        {
            return await _organizationService.GetListAsync(key);
        }

        /// <summary>
        /// 新增组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody]OrganizationAddInput input)
        {
            return await _organizationService.AddAsync(input);
        }

        /// <summary>
        /// 修改组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] OrganizationUpdateInput input)
        {
            return await _organizationService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除组织架构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> SoftDelete(Guid id)
        {
            return await _organizationService.DeleteAsync(id);
        }
    }
}