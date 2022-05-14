using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Paas.Pioneer.Information.Domain.News;
using Paas.Pioneer.Information.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.News
{
    public class EfCoreNewsRepository : BaseExtensionsRepository<Information_NewsEntity>, INewsRepository
    {
        private readonly IRepository<Information_NewsEntity> _newsRepository;
        public EfCoreNewsRepository(IDbContextProvider<InformationsDbContext> dbContextProvider,
            IRepository<Information_NewsEntity> newsRepository)
            : base(dbContextProvider)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Page<GetNewsPageListOutput>> GetPageListAsync(PageInput<GetNewsPageListInput> input)
        {
            var newsQueryable = await _newsRepository.GetQueryableAsync();
            var data = from news in newsQueryable.WhereDynamicFilter(input.DynamicFilter)
                       select new GetNewsPageListOutput
                       {
                           DictionaryId = news.DictionaryId,
                           Portrait = news.Portrait,
                           PushTime = news.PushTime,
                           NewsContent = news.NewsContent,
                           Hidden = news.Hidden,
                           Enabled = news.Enabled,
                           Sort = news.Sort,
                           Description = news.Description,
                           CreationTime = news.CreationTime,
                           Id = news.Id,
                       };

            Page<GetNewsPageListOutput> page = new Page<GetNewsPageListOutput>
            {
                Total = await data.LongCountAsync(),
                List = await data.OrderByDescending(x => x.Sort).Page(input.CurrentPage, input.PageSize).ToListAsync()
            };
            return page;
        }
    }
}

