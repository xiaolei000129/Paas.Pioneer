using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Slideshow;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Information.Domain.Slideshow;
using Paas.Pioneer.Admin.Core.HttpApi.Client.ServiceProxies;

namespace Paas.Pioneer.Information.Application.Slideshow
{
    /// <summary>
    /// 幻灯片管理服务
    /// </summary>
    public class SlideshowService : ApplicationService, ISlideshowService
    {

        private readonly ISlideshowRepository _slideshowRepository;
        private readonly IDictionaryServiceProxy _dictionaryServiceProxy;


        /// <summary>
        /// 构造函数
        /// </summary>
        public SlideshowService(ISlideshowRepository slideshowRepository,
            IDictionaryServiceProxy dictionaryServiceProxy)
        {
            _slideshowRepository = slideshowRepository;
            _dictionaryServiceProxy = dictionaryServiceProxy;
        }

        /// <summary>
        /// 查询幻灯片管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<GetSlideshowOutput> GetAsync(Guid id)
        {
            var result = await _slideshowRepository.GetAsync(p => p.Id == id, x => new GetSlideshowOutput()
            {
                DictionaryId = x.DictionaryId,
                SlideshowType = x.SlideshowType,
                Expand = x.Expand,
                Title = x.Title,
                Portrait = x.Portrait,
                Sort = x.Sort,
                Description = x.Description,
                LastModificationTime = x.LastModificationTime,
                CreationTime = x.CreationTime,
                Id = x.Id,
            });
            return result;
        }

        /// <summary>
        /// 查询分页幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<Page<GetSlideshowPageListOutput>> GetPageListAsync(PageInput<GetSlideshowPageListInput> input)
        {
            var pageData = await _slideshowRepository.GetPageListAsync(input);
            var dictionaryList = await _dictionaryServiceProxy.GetListAsync(pageData.List.Select(x => x.DictionaryId).ToArray());
            foreach (var item in pageData.List)
            {
                var dictionary = dictionaryList.FirstOrDefault(x => x.Id == item.DictionaryId);
                if (dictionary != null)
                {
                    item.DictionaryName = dictionary.Name;
                }
            }
            return pageData;
        }

        /// <summary>
        /// 新增幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task AddAsync(AddSlideshowInput input)
        {
            var slideshow = ObjectMapper.Map<AddSlideshowInput, Information_SlideshowEntity>(input);
            await _slideshowRepository.InsertAsync(slideshow);
        }

        /// <summary>
        /// 修改幻灯片管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateSlideshowInput input)
        {
            var entity = await _slideshowRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                throw new BusinessException("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _slideshowRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除幻灯片管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _slideshowRepository.DeleteAsync(m => m.Id == id);
        }

        /// <summary>
        /// 批量删除幻灯片管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _slideshowRepository.DeleteAsync(x => ids.Contains(x.Id));
        }
    }
}