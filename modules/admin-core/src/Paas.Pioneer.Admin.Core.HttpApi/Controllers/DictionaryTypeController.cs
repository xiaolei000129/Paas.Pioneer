using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 数据字典类型
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class DictionaryTypeController : AbpControllerBase
    {
        private readonly IDictionaryTypeService _dictionaryTypeService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dictionaryTypeService"></param>
        public DictionaryTypeController(IDictionaryTypeService dictionaryTypeService)
        {
            _dictionaryTypeService = dictionaryTypeService;
        }

        /// <summary>
        /// 查询单条数据字典类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<DictionaryTypeGetOutput>> Get(Guid id)
        {
            return await _dictionaryTypeService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页数据字典类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Page<DictionaryTypeOutput>>> GetPageList(PageInput<DictionaryTypeInput> model)
        {
            return await _dictionaryTypeService.GetPageListAsync(model);
        }

        /// <summary>
        /// 新增数据字典类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] DictionaryTypeAddInput input)
        {
            return await _dictionaryTypeService.AddAsync(input);
        }

        /// <summary>
        /// 修改数据字典类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] DictionaryTypeUpdateInput input)
        {
            return await _dictionaryTypeService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除数据字典类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> SoftDelete(Guid id)
        {
            return await _dictionaryTypeService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除数据字典类型
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _dictionaryTypeService.BatchSoftDeleteAsync(ids);
        }
    }
}