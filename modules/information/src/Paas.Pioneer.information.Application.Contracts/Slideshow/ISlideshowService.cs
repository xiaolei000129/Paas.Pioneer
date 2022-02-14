using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Information.Application.Contracts.Slideshow
{
    /// <summary>
    /// Slideshow接口
    /// </summary>
    public interface ISlideshowService : IApplicationService
    {
        /// <summary>
        /// 查询Slideshow
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<ResponseOutput<GetSlideshowOutput>> GetAsync(Guid id);

        /// <summary>
        /// 查询分页Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<GetSlideshowPageListOutput>>> GetPageListAsync(PageInput<GetSlideshowPageListInput> model);

        /// <summary>
        /// 新增Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> AddAsync(AddSlideshowInput input);

        /// <summary>
        /// 修改Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> UpdateAsync(UpdateSlideshowInput input);

        /// <summary>
        /// 删除Slideshow
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<IResponseOutput> DeleteAsync(Guid id);

        /// <summary>
        /// 批量删除Slideshow
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}