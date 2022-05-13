using Paas.Pioneer.Domain.Shared.Dto.Input;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Paas.Pioneer.Domain.Shared.Extensions;
using Paas.Pioneer.Information.Domain.Grid;
using Paas.Pioneer.Information.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.Grid
{
    public class EfCoreGridRepository : BaseExtensionsRepository<Information_GridEntity>, IGridRepository
    {
        private readonly IRepository<Information_GridEntity> _gridRepository;
        public EfCoreGridRepository(IDbContextProvider<InformationsDbContext> dbContextProvider,
            IRepository<Information_GridEntity> gridRepository)
            : base(dbContextProvider)
        {
            _gridRepository = gridRepository;
        }

        public async Task<Page<GetGridPageListOutput>> GetPageListAsync(PageInput<GetGridPageListInput> input)
        {
            var gridQueryable = await _gridRepository.GetQueryableAsync();
            var data = from grid in gridQueryable.WhereDynamicFilter(input.DynamicFilter)
                       select new GetGridPageListOutput
                       {
                           DictionaryId = grid.DictionaryId,
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

