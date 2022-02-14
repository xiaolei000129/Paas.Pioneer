using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.News;

namespace Paas.Pioneer.Information.HttpApi.Controllers.News
{
    /// <summary>
    /// News
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class NewsController : AbpController
    {

        private readonly INewsService _newsService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// 查询News
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<GetNewsOutput>> Get(Guid id)
        {
            return await _newsService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Page<GetNewsPageListOutput>>> GetPageList(PageInput<GetNewsPageListInput> input)
        {
            return await _newsService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] AddNewsInput input)
        {
            return await _newsService.AddAsync(input);
        }

        /// <summary>
        /// 修改News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] UpdateNewsInput input)
        {
            return await _newsService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除News
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> Delete(Guid id)
        {
            return await _newsService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除News
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _newsService.BatchSoftDeleteAsync(ids);
        }
    }
}