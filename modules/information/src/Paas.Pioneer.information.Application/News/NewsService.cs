using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.News;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Information.Domain.News;
using Paas.Pioneer.Information.Domain.Slideshow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Information.Application.News
{
    /// <summary>
    /// News服务
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
        /// 查询News
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<ResponseOutput<GetNewsOutput>> GetAsync(Guid id)
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
            return ResponseOutput.Succees(result);
        }

        /// <summary>
        /// 查询分页News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<GetNewsPageListOutput>>> GetPageListAsync(PageInput<GetNewsPageListInput> input)
        {
            return await _newsRepository.GetResponseOutputPageListAsync(selector: x => new GetNewsPageListOutput
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
            }, input: input);
        }

        /// <summary>
        /// 新增News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> AddAsync(AddNewsInput input)
        {
            var news = ObjectMapper.Map<AddNewsInput, Information_NewsEntity>(input);
            await _newsRepository.InsertAsync(news);
            return ResponseOutput.Succees("添加成功！");
        }

        /// <summary>
        /// 修改News
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateAsync(UpdateNewsInput input)
        {
            var entity = await _newsRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                return ResponseOutput.Error("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _newsRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        /// <summary>
        /// 删除News
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _newsRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees("删除成功！");
        }

        /// <summary>
        /// 批量删除News
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _newsRepository.DeleteAsync(x => ids.Contains(x.Id));
            return ResponseOutput.Succees("删除成功！");
        }
    }
}