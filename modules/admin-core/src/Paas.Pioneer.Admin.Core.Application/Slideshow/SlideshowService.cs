using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Slideshow;
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

namespace Paas.Pioneer.Admin.Core.Application.Slideshow
{
    /// <summary>
    /// 幻灯片管理服务
    /// </summary>
     public class SlideshowService : ApplicationService, ISlideshowService
    {
        
        private readonly ISlideshowRepository _slideshowRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SlideshowService(ISlideshowRepository slideshowRepository)
        {
            _slideshowRepository = slideshowRepository;
        }

        /// <summary>
        /// 查询幻灯片管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<GetSlideshowOutput> GetAsync(Guid id)
        {
            var result = await _slideshowRepository.GetAsync(p=>p.Id == id, x => new GetSlideshowOutput()
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
            var data = await _slideshowRepository.GetResponseOutputPageListAsync(x => new GetSlideshowPageListOutput
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
            }, input: input);
            return data;
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