using Paas.Pioneer.Admin.Core.Domain.Slideshow;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Paas.Pioneer.Admin.Core.Domain.Grid;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Slideshow
{
    public class EfCoreSlideshowRepository : BaseExtensionsRepository<Information_SlideshowEntity>, ISlideshowRepository
    {
        private readonly IRepository<Ad_DictionaryEntity> _dictionaryRepository;
        private readonly IRepository<Information_SlideshowEntity> _slideshowRepository;
        public EfCoreSlideshowRepository(IDbContextProvider<AdminsDbContext> dbContextProvider,
            IRepository<Ad_DictionaryEntity> dictionaryRepository,
            IRepository<Information_SlideshowEntity> slideshowRepository)
            : base(dbContextProvider)
        {
            _dictionaryRepository = dictionaryRepository;
            _slideshowRepository = slideshowRepository;
        }

        public async Task<Page<GetSlideshowPageListOutput>> GetPageListAsync(PageInput<GetSlideshowPageListInput> input)
        {
            var slideshowQueryable = await _slideshowRepository.GetQueryableAsync();
            var dictionaryQueryable = await _dictionaryRepository.GetQueryableAsync();
            var data = from slideshow in slideshowQueryable.WhereDynamicFilter(input.DynamicFilter)
                       join dictionary in dictionaryQueryable
                       on slideshow.DictionaryId equals dictionary.Id
                       select new GetSlideshowPageListOutput
                       {
                           DictionaryId = slideshow.DictionaryId,
                           DictionaryName = dictionary.Name,
                           SlideshowType = slideshow.SlideshowType,
                           Expand = slideshow.Expand,
                           Title = slideshow.Title,
                           Portrait = slideshow.Portrait,
                           Sort = slideshow.Sort,
                           Description = slideshow.Description,
                           CreationTime = slideshow.CreationTime,
                           Id = slideshow.Id,
                       };

            Page<GetSlideshowPageListOutput> page = new Page<GetSlideshowPageListOutput>
            {
                Total = await data.LongCountAsync(),
                List = await data.OrderByDescending(x => x.Sort).Page(input.CurrentPage, input.PageSize).ToListAsync()
            };
            return page;
        }
    }
}

