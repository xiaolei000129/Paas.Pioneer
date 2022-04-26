using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
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
    /// 低代码表格配置
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class LowCodeTableConfigController : AbpControllerBase
    {
        private readonly ILowCodeTableConfigService _lowCodeTableConfigService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lowCodeTableConfigService"></param>
        public LowCodeTableConfigController(ILowCodeTableConfigService lowCodeTableConfigService)
        {
            _lowCodeTableConfigService = lowCodeTableConfigService;
        }

        /// <summary>
        /// 查询分页低代码表格配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Page<LowCodeTableConfigOutput>> GetPageList(PageInput<GetLowCodeTableConfigPadedInput> input)
        {
            return await _lowCodeTableConfigService.GetLowCodeTableConfigPageListAsync(input);
        }

        /// <summary>
        /// 新增低代码表格配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] AddLowCodeTableConfigInput input)
        {
            await _lowCodeTableConfigService.AddLowCodeTableConfigAsync(input);
        }

        /// <summary>
        /// 修改低代码表格配置
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] List<EditLowCodeTableConfigInput> inputList)
        {
            await _lowCodeTableConfigService.EditLowCodeTableConfigAsync(inputList);
        }

        /// <summary>
        /// 删除低代码表格配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _lowCodeTableConfigService.DelLowCodeTableConfigAsync(id);
        }
    }
}