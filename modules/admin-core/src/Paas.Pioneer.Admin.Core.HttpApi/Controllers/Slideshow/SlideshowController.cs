using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 幻灯片管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class SlideshowController : AbpController
    {
        
        private readonly ISlideshowService _slideshowService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SlideshowController(ISlideshowService slideshowService)
        {
            _slideshowService = slideshowService;
        }

        /// <summary>
        /// 查询幻灯片管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetSlideshowOutput> Get(Guid id)
        {
            return await _slideshowService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Page<GetSlideshowPageListOutput>> GetPageList(PageInput<GetSlideshowPageListInput> input)
        {
            return await _slideshowService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] AddSlideshowInput input)
        {
            await _slideshowService.AddAsync(input);
        }

        /// <summary>
        /// 修改幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] UpdateSlideshowInput input)
        {
            await _slideshowService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除幻灯片管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _slideshowService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除幻灯片管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _slideshowService.BatchSoftDeleteAsync(ids);
        }
    }
}