using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.News;

namespace Paas.Pioneer.Information.HttpApi.Controllers.News
{
    /// <summary>
    /// 新闻管理
    /// </summary>
    [Route("api/info/[controller]/[action]")]
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
        /// 查询新闻管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetNewsOutput> Get(Guid id)
        {
            return await _newsService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Page<GetNewsPageListOutput>> GetPageList([FromBody] PageInput<GetNewsPageListInput> input)
        {
            return await _newsService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] AddNewsInput input)
        {
            await _newsService.AddAsync(input);
        }

        /// <summary>
        /// 修改新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] UpdateNewsInput input)
        {
            await _newsService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除新闻管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDelete(Guid id)
        {
            await _newsService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除新闻管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _newsService.BatchSoftDeleteAsync(ids);
        }
    }
}