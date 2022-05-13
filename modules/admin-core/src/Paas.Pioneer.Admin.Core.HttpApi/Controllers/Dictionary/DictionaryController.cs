using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System.Collections.Generic;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class DictionaryController : AbpControllerBase
    {
        private readonly IDictionaryService _dictionaryService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dictionaryService"></param>
        public DictionaryController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        /// <summary>
        /// 查询单条数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetDictionaryOutput> Get(Guid id)
        {
            return await _dictionaryService.GetAsync(id);
        }

        /// <summary>
        /// 查询数据字典
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<GetDictionaryOutput>> GetList(Guid[] ids)
        {
            return await _dictionaryService.GetListAsync(ids);
        }

        /// <summary>
        /// 查询分页数据字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Page<DictionaryPageListOutput>> GetPageList([FromBody] PageInput<DictionaryInput> model)
        {
            return await _dictionaryService.GetPageListAsync(model);
        }

        /// <summary>
        /// 新增数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] DictionaryAddInput input)
        {
            await _dictionaryService.AddAsync(input);
        }

        /// <summary>
        /// 修改数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] DictionaryUpdateInput input)
        {
            await _dictionaryService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除数据字典类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDelete(Guid id)
        {
            await _dictionaryService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除数据字典
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _dictionaryService.BatchSoftDeleteAsync(ids);
        }
    }
}