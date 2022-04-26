using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output;
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
    /// 低代码表格
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class LowCodeTableController : AbpControllerBase
    {
        private readonly ILowCodeTableService _lowCodeTableService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="LowCodeTableService"></param>
        public LowCodeTableController(ILowCodeTableService LowCodeTableService)
        {
            _lowCodeTableService = LowCodeTableService;
        }


        /// <summary>
        /// 查询分页低代码表格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Page<LowCodeTableOutput>> GetPageList(PageInput<GetLowCodeTablePadedInput> input)
        {
            return await _lowCodeTableService.GetLowCodeTablePageListAsync(input);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<LowCodeTableOutput> Get(Guid id)
        {
            return await _lowCodeTableService.GetAsync(id);
        }

        /// <summary>
        /// 新增低代码表格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] AddLowCodeTableInput input)
        {
            await _lowCodeTableService.AddLowCodeTableAsync(input);
        }

        /// <summary>
        /// 修改低代码表格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] EditLowCodeTableInput input)
        {
            await _lowCodeTableService.EditLowCodeTableAsync(input);
        }

        /// <summary>
        /// 删除低代码表格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _lowCodeTableService.DelLowCodeTableAsync(id);
        }

        /// <summary>
        /// 批量删除低代码表格
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task BatchDelete([FromBody] Guid[] ids)
        {
            await _lowCodeTableService.BatchDeleteAsync(ids);
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<LowCodeTableEntityOutput>> GetTableEntityList()
        {
            return await _lowCodeTableService.GetTableEntityListAsync();
        }

        /// <summary>
        /// 根据表或者字段
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<LowCodeTableColumnOutput>> GetColumnListByTableName(Guid id)
        {
            return await _lowCodeTableService.GetColumnListByTableNameAsync(id);
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task GenerateCode(Guid id)
        {
            await _lowCodeTableService.GenerateCodeAsync(id);
        }
    }
}