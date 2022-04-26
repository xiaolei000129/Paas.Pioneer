using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Api.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 接口管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class ApiController : AbpControllerBase
    {
        private readonly IApiService _apiService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="apiService"></param>
        public ApiController(IApiService apiService)
        {
            _apiService = apiService;
        }

        /// <summary>
        /// 查询单条接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<ApiGetOutput>> Get(Guid id)
        {
            return await _apiService.GetAsync(id);
        }

        /// <summary>
        /// 查询全部接口
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<List<ApiListOutput>>> GetList(string key)
        {
            return await _apiService.GetListAsync(key);
        }

        /// <summary>
        /// 查询分页接口(没有用使用)
        /// </summary>
        /// <param name="model">分页模型</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Page<ApiListOutput>>> GetPageList(PageInput<ApiInput> model)
        {
            return await _apiService.GetPageListAsync(model);
        }

        /// <summary>
        /// 新增接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] ApiAddInput input)
        {
            await _apiService.AddAsync(input);
        }

        /// <summary>
        /// 修改接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] ApiUpdateInput input)
        {
            await _apiService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDeleteAsync(Guid id)
        {
            await _apiService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除数据字典
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _apiService.BatchSoftDeleteAsync(ids);
        }
    }
}