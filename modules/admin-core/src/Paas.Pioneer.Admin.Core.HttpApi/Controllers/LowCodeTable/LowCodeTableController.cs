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
        public async Task<ResponseOutput<Page<LowCodeTableOutput>>> GetPageList(PageInput<GetLowCodeTablePadedInput> input)
        {
            return await _lowCodeTableService.GetLowCodeTablePageListAsync(input);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResponseOutput<LowCodeTableOutput>> Get(Guid id)
        {
            return await _lowCodeTableService.GetAsync(id);
        }

        /// <summary>
        /// 新增低代码表格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] AddLowCodeTableInput input)
        {
            return await _lowCodeTableService.AddLowCodeTableAsync(input);
        }

        /// <summary>
        /// 修改低代码表格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] EditLowCodeTableInput input)
        {
            return await _lowCodeTableService.EditLowCodeTableAsync(input);
        }

        /// <summary>
        /// 删除低代码表格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> Delete(Guid id)
        {
            return await _lowCodeTableService.DelLowCodeTableAsync(id);
        }

        /// <summary>
        /// 批量删除低代码表格
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> BatchDelete([FromBody] Guid[] ids)
        {
            return await _lowCodeTableService.BatchDeleteAsync(ids);
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResponseOutput<IEnumerable<LowCodeTableEntityOutput>>> GetTableEntityList()
        {
            return await _lowCodeTableService.GetTableEntityListAsync();
        }

        /// <summary>
        /// 根据表或者字段
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResponseOutput<List<LowCodeTableColumnOutput>>> GetColumnListByTableName(Guid id)
        {
            return await _lowCodeTableService.GetColumnListByTableNameAsync(id);
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResponseOutput> GenerateCode(Guid id)
        {
            return await _lowCodeTableService.GenerateCodeAsync(id);
        }
    }
}