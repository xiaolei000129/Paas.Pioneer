using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.News
{
    /// <summary>
    /// 新闻管理接口
    /// </summary>
    public interface INewsService : IApplicationService
    {
        /// <summary>
        /// 查询新闻管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetNewsOutput> GetAsync(Guid id);

        /// <summary>
        /// 查询分页新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<Page<GetNewsPageListOutput>> GetPageListAsync(PageInput<GetNewsPageListInput> model);

        /// <summary>
        /// 新增新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task AddAsync(AddNewsInput input);

        /// <summary>
        /// 修改新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateNewsInput input);

        /// <summary>
        /// 删除新闻管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
        
        /// <summary>
        /// 批量删除新闻管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}