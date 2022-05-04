using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Grid
{
    /// <summary>
    /// 栅格管理接口
    /// </summary>
    public interface IGridService : IApplicationService
    {
        /// <summary>
        /// 查询栅格管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetGridOutput> GetAsync(Guid id);

        /// <summary>
        /// 查询分页栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<Page<GetGridPageListOutput>> GetPageListAsync(PageInput<GetGridPageListInput> model);

        /// <summary>
        /// 新增栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task AddAsync(AddGridInput input);

        /// <summary>
        /// 修改栅格管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateGridInput input);

        /// <summary>
        /// 删除栅格管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
        
        /// <summary>
        /// 批量删除栅格管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}