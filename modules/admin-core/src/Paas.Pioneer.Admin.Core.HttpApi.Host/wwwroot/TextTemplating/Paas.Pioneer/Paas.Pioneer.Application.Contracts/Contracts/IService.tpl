using Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}
{
    /// <summary>
    /// {{model.function_module}}接口
    /// </summary>
    public interface I{{model.taxon}}Service : IApplicationService
    {
        /// <summary>
        /// 查询{{model.function_module}}
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<Get{{model.taxon}}Output> GetAsync(Guid id);

        /// <summary>
        /// 查询分页{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<Page<Get{{model.taxon}}PageListOutput>> GetPageListAsync(PageInput<Get{{model.taxon}}PageListInput> model);

        /// <summary>
        /// 新增{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task AddAsync(Add{{model.taxon}}Input input);

        /// <summary>
        /// 修改{{model.function_module}}
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task UpdateAsync(Update{{model.taxon}}Input input);

        /// <summary>
        /// 删除{{model.function_module}}
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
        
        /// <summary>
        /// 批量删除{{model.function_module}}
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}