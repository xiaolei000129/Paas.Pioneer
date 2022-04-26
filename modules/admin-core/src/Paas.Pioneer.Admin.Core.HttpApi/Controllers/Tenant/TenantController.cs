using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.TenantManagement;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 租户管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class TenantController : AbpControllerBase
    {
        private readonly ITenantService _tenantServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tenantService"></param>
        public TenantController(ITenantService tenantService)
        {
            _tenantServices = tenantService;
        }

        /// <summary>
        /// 查询单条租户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TenantGetOutput> Get(Guid id)
        {
            return await _tenantServices.GetAsync(id);
        }

        /// <summary>
        /// 查询分页租户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Page<GetTenantPageListOutput>> GetPageList(PageInput<GetTenantsInput> model)
        {
            return await _tenantServices.GetPageListAsync(model);
        }

        /// <summary>
        /// 新增租户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] TenantAddInput input)
        {
            await _tenantServices.AddAsync(input);
        }

        /// <summary>
        /// 修改租户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] TenantUpdateInput input)
        {
            await _tenantServices.UpdateAsync(input);
        }

        /// <summary>
        /// 彻底删除租户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _tenantServices.DeleteAsync(id);
        }

        /// <summary>
        /// 删除租户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDelete(Guid id)
        {
            await _tenantServices.SoftDeleteAsync(id);
        }

        /// <summary>
        /// 批量删除租户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _tenantServices.BatchSoftDeleteAsync(ids);
        }
    }
}
