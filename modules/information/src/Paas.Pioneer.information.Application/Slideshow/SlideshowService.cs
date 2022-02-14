using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Slideshow;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Information.Domain.Grid;
using Paas.Pioneer.Information.Domain.Slideshow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Information.Application.Slideshow
{
    /// <summary>
    /// Slideshow服务
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
        /// 查询Slideshow
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<ResponseOutput<GetSlideshowOutput>> GetAsync(Guid id)
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
            return ResponseOutput.Succees(result);
        }

        /// <summary>
        /// 查询分页Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<GetSlideshowPageListOutput>>> GetPageListAsync(PageInput<GetSlideshowPageListInput> input)
        {
            return await _slideshowRepository.GetResponseOutputPageListAsync(selector: x => new GetSlideshowPageListOutput
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
        }

        /// <summary>
        /// 新增Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> AddAsync(AddSlideshowInput input)
        {
            var slideshow = ObjectMapper.Map<AddSlideshowInput, Information_SlideshowEntity>(input);
            await _slideshowRepository.InsertAsync(slideshow);
            return ResponseOutput.Succees("添加成功！");
        }

        /// <summary>
        /// 修改Slideshow
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateAsync(UpdateSlideshowInput input)
        {
            var entity = await _slideshowRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                return ResponseOutput.Error("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _slideshowRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        /// <summary>
        /// 删除Slideshow
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _slideshowRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees("删除成功！");
        }

        /// <summary>
        /// 批量删除Slideshow
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _slideshowRepository.DeleteAsync(x => ids.Contains(x.Id));
            return ResponseOutput.Succees("删除成功！");
        }
    }
}