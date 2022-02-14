using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Information.Application.Contracts.Grid
{
    /// <summary>
    /// Grid接口
    /// </summary>
    public interface IGridService : IApplicationService
    {
        /// <summary>
        /// 查询Grid
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<ResponseOutput<GetGridOutput>> GetAsync(Guid id);

        /// <summary>
        /// 查询分页Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<GetGridPageListOutput>>> GetPageListAsync(PageInput<GetGridPageListInput> model);

        /// <summary>
        /// 新增Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> AddAsync(AddGridInput input);

        /// <summary>
        /// 修改Grid
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> UpdateAsync(UpdateGridInput input);

        /// <summary>
        /// 删除Grid
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<IResponseOutput> DeleteAsync(Guid id);

        /// <summary>
        /// 批量删除Grid
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}