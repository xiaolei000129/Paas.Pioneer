using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow
{
    /// <summary>
    /// 幻灯片管理接口
    /// </summary>
    public interface ISlideshowService : IApplicationService
    {
        /// <summary>
        /// 查询幻灯片管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetSlideshowOutput> GetAsync(Guid id);

        /// <summary>
        /// 查询分页幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<Page<GetSlideshowPageListOutput>> GetPageListAsync(PageInput<GetSlideshowPageListInput> model);

        /// <summary>
        /// 新增幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task AddAsync(AddSlideshowInput input);

        /// <summary>
        /// 修改幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task UpdateAsync(UpdateSlideshowInput input);

        /// <summary>
        /// 删除幻灯片管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
        
        /// <summary>
        /// 批量删除幻灯片管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}