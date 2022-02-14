using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Information.Application.Contracts.News
{
    /// <summary>
    /// News接口
    /// </summary>
    public interface INewsService : IApplicationService
    {
        /// <summary>
        /// 查询News
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<ResponseOutput<GetNewsOutput>> GetAsync(Guid id);

        /// <summary>
        /// 查询分页News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<GetNewsPageListOutput>>> GetPageListAsync(PageInput<GetNewsPageListInput> model);

        /// <summary>
        /// 新增News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> AddAsync(AddNewsInput input);

        /// <summary>
        /// 修改News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> UpdateAsync(UpdateNewsInput input);

        /// <summary>
        /// 删除News
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<IResponseOutput> DeleteAsync(Guid id);

        /// <summary>
        /// 批量删除News
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}