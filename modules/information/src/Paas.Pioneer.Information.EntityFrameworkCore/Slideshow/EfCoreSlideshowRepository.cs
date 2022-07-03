using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using Paas.Pioneer.Information.Domain.Slideshow;
using Paas.Pioneer.Information.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.Slideshow
{
    public class EfCoreSlideshowRepository : BaseExtensionsRepository<Information_SlideshowEntity>, ISlideshowRepository
    {
        public EfCoreSlideshowRepository(IDbContextProvider<InformationsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Page<GetSlideshowPageListOutput>> GetPageListAsync(PageInput<GetSlideshowPageListInput> input)
        {
            var slideshowQueryable = await GetQueryableAsync();
            var data = from slideshow in slideshowQueryable.WhereDynamicFilter(input.DynamicFilter)
                       select new GetSlideshowPageListOutput
                       {
                           DictionaryId = slideshow.DictionaryId,
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

