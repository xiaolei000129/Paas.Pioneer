using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{ model.taxon }}.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{ model.taxon }}.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{ model.taxon }};
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// {{ model.function_module }}
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class {{ model.taxon }}Controller : AbpController
    {
        {{
            func initial_lower
                ret ( model.taxon | string.slice1 0 | string.downcase ) + (model.taxon | string.slice 1 )
        end}}
        private readonly I{{model.taxon}}Service _{{ initial_lower }}Service;

        /// <summary>
        /// 构造函数
        /// </summary>
        public {{model.taxon}}Controller(I{{model.taxon}}Service {{ initial_lower }}Service)
        {
            _{{ initial_lower }}Service = {{ initial_lower }}Service;
        }

        /// <summary>
        /// 查询{{model.function_module}}
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Get{{model.taxon}}Output>> Get(Guid id)
        {
            return await _{{ initial_lower }}Service.GetAsync(id);
        }

        /// <summary>
        /// 查询分页{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Page<Get{{model.taxon}}PageListOutput>>> GetPageList(PageInput<Get{{model.taxon}}PageListInput> input)
        {
            return await _{{ initial_lower }}Service.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] Add{{model.taxon}}Input input)
        {
            return await _{{ initial_lower }}Service.AddAsync(input);
        }

        /// <summary>
        /// 修改{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Update{{model.taxon}}Input input)
        {
            return await _{{ initial_lower }}Service.UpdateAsync(input);
        }

        /// <summary>
        /// 删除{{model.function_module}}
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            return await _{{ initial_lower }}Service.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除{{model.function_module}}
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _{{ initial_lower }}Service.BatchSoftDeleteAsync(ids);
        }
    }
}