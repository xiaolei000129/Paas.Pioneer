using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.News;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.News;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.News
{
    /// <summary>
    /// 新闻管理服务
    /// </summary>
    public class NewsService : ApplicationService, INewsService
    {

        private readonly INewsRepository _newsRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        /// <summary>
        /// 查询新闻管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<GetNewsOutput> GetAsync(Guid id)
        {
            var result = await _newsRepository.GetAsync(p => p.Id == id, x => new GetNewsOutput()
            {
                DictionaryId = x.DictionaryId,
                Portrait = x.Portrait,
                PushTime = x.PushTime,
                NewsContent = x.NewsContent,
                Hidden = x.Hidden,
                Enabled = x.Enabled,
                Sort = x.Sort,
                Description = x.Description,
                LastModificationTime = x.LastModificationTime,
                CreationTime = x.CreationTime,
                Id = x.Id,
            });
            return result;
        }

        /// <summary>
        /// 查询分页新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<Page<GetNewsPageListOutput>> GetPageListAsync(PageInput<GetNewsPageListInput> input)
        {
            return await _newsRepository.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task AddAsync(AddNewsInput input)
        {
            var news = ObjectMapper.Map<AddNewsInput, Information_NewsEntity>(input);
            await _newsRepository.InsertAsync(news);
        }

        /// <summary>
        /// 修改新闻管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateNewsInput input)
        {
            var entity = await _newsRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                throw new BusinessException("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _newsRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除新闻管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _newsRepository.DeleteAsync(m => m.Id == id);
        }

        /// <summary>
        /// 批量删除新闻管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _newsRepository.DeleteAsync(x => ids.Contains(x.Id));
        }
    }
}