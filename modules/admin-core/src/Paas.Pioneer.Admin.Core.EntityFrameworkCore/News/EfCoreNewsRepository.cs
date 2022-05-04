using Paas.Pioneer.Admin.Core.Domain.News;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Domain.Shared.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.News
{
    public class EfCoreNewsRepository : BaseExtensionsRepository<Information_NewsEntity>, INewsRepository
    {
        private readonly IRepository<Ad_DictionaryEntity> _dictionaryRepository;
        private readonly IRepository<Information_NewsEntity> _newsRepository;
        public EfCoreNewsRepository(IDbContextProvider<AdminsDbContext> dbContextProvider,
            IRepository<Ad_DictionaryEntity> dictionaryRepository,
            IRepository<Information_NewsEntity> newsRepository)
            : base(dbContextProvider)
        {
            _dictionaryRepository = dictionaryRepository;
            _newsRepository = newsRepository;
        }

        public async Task<Page<GetNewsPageListOutput>> GetPageListAsync(PageInput<GetNewsPageListInput> input)
        {
            var newsQueryable = await _newsRepository.GetQueryableAsync();
            var dictionaryQueryable = await _dictionaryRepository.GetQueryableAsync();
            var data = from news in newsQueryable.WhereDynamicFilter(input.DynamicFilter)
                       join dictionary in dictionaryQueryable
                       on news.DictionaryId equals dictionary.Id
                       select new GetNewsPageListOutput
                       {
                           DictionaryId = news.DictionaryId,
                           DictionaryName = dictionary.Name,
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

