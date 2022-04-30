using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}};
using Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.{{model.taxon}};
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.{{model.taxon}}
{
    /// <summary>
    /// {{model.function_module}}服务
    /// </summary>
     public class {{model.taxon}}Service : ApplicationService, I{{model.taxon}}Service
    {
        {{
            func initial_lower
                ret ( model.taxon | string.slice1 0 | string.downcase ) + (model.taxon | string.slice 1 )
        end}}
        private readonly I{{model.taxon}}Repository _{{ initial_lower }}Repository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public {{model.taxon}}Service(I{{model.taxon}}Repository {{ initial_lower }}Repository)
        {
            _{{ initial_lower }}Repository = {{ initial_lower }}Repository;
        }

        /// <summary>
        /// 查询{{model.function_module}}
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<Get{{model.taxon}}Output> GetAsync(Guid id)
        {
            var result = await _{{ initial_lower }}Repository.GetAsync(p=>p.Id == id, x => new Get{{model.taxon}}Output()
            {
                {{~ for item in model.low_code_table_config_list ~}}
                {{ item.column_name }} = x.{{ item.column_name }},
                {{~ end ~}}
            });
            return result;
        }

        /// <summary>
        /// 查询分页{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<Page<Get{{model.taxon}}PageListOutput>> GetPageListAsync(PageInput<Get{{model.taxon}}PageListInput> input)
        {
            var data = await _{{ initial_lower }}Repository.GetResponseOutputPageListAsync(x => new Get{{model.taxon}}PageListOutput
            {
                {{~ for item in model.low_code_table_config_list ~}}
                {{ item.column_name }} = x.{{ item.column_name }},
                {{~ end ~}}
            }, input: input);
            return data;
        }

        /// <summary>
        /// 新增{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task AddAsync(Add{{model.taxon}}Input input)
        {
            var {{ initial_lower }} = ObjectMapper.Map<Add{{model.taxon}}Input, {{ model.low_code_table_name }}>(input);
            await _{{ initial_lower }}Repository.InsertAsync({{ initial_lower }});
        }

        /// <summary>
        /// 修改{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task UpdateAsync(Update{{model.taxon}}Input input)
        {
            var entity = await _{{ initial_lower }}Repository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                throw new BusinessException("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _{{ initial_lower }}Repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除{{model.function_module}}
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _{{ initial_lower }}Repository.DeleteAsync(m => m.Id == id);
        }

        /// <summary>
        /// 批量删除{{model.function_module}}
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _{{ initial_lower }}Repository.DeleteAsync(x => ids.Contains(x.Id));
        }
    }
}