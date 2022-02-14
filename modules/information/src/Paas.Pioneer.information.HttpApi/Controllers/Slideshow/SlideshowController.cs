using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Slideshow;

namespace Paas.Pioneer.Information.HttpApi.Controllers.Slideshow
{
    /// <summary>
    /// Slideshow
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
        /// 查询Slideshow
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<GetSlideshowOutput>> Get(Guid id)
        {
            return await _slideshowService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Page<GetSlideshowPageListOutput>>> GetPageList(PageInput<GetSlideshowPageListInput> input)
        {
            return await _slideshowService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] AddSlideshowInput input)
        {
            return await _slideshowService.AddAsync(input);
        }

        /// <summary>
        /// 修改Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] UpdateSlideshowInput input)
        {
            return await _slideshowService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除Slideshow
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> Delete(Guid id)
        {
            return await _slideshowService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除Slideshow
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _slideshowService.BatchSoftDeleteAsync(ids);
        }
    }
}