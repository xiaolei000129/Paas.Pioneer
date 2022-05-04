using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Grid;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Paas.Pioneer.Domain.Shared.Extensions;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Grid
{
    public class EfCoreGridRepository : BaseExtensionsRepository<Information_GridEntity>, IGridRepository
    {
        private readonly IRepository<Ad_DictionaryEntity> _dictionaryRepository;
        private readonly IRepository<Information_GridEntity> _gridRepository;
        public EfCoreGridRepository(IDbContextProvider<AdminsDbContext> dbContextProvider,
            IRepository<Ad_DictionaryEntity> dictionaryRepository,
            IRepository<Information_GridEntity> gridRepository)
            : base(dbContextProvider)
        {
            _dictionaryRepository = dictionaryRepository;
            _gridRepository = gridRepository;
        }

        public async Task<Page<GetGridPageListOutput>> GetPageListAsync(PageInput<GetGridPageListInput> input)
        {
            var gridQueryable = await _gridRepository.GetQueryableAsync();
            var dictionaryQueryable = await _dictionaryRepository.GetQueryableAsync();
            var data = from grid in gridQueryable.WhereDynamicFilter(input.DynamicFilter)
                       join dictionary in dictionaryQueryable
                       on grid.DictionaryId equals dictionary.Id
                       select new GetGridPageListOutput
                       {
                           DictionaryId = grid.DictionaryId,
                           DictionaryName = dictionary.Name,
                           GridType = grid.GridType,
                           Name = grid.Name,
                           Portrait = grid.Portrait,
                           Expand = grid.Expand,
                           Sort = grid.Sort,
                           Description = grid.Description,
                           LastModificationTime = grid.LastModificationTime,
                           CreationTime = grid.CreationTime,
                           Id = grid.Id,
                       };

            Page<GetGridPageListOutput> page = new Page<GetGridPageListOutput>
            {
                Total = await data.LongCountAsync(),
                List = await data.OrderByDescending(x => x.Sort).Page(input.CurrentPage, input.PageSize).ToListAsync()
            };
            return page;
        }
    }
}

