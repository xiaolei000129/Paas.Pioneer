using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTable;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Extensions;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.LowCodeTable
{
    public class EfCoreLowCodeTableRepository : BaseExtensionsRepository<Ad_LowCodeTableEntity>, ILowCodeTableRepository
    {
        public EfCoreLowCodeTableRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<Page<LowCodeTableOutput>> GetLowCodeTablePageListAsync(PageInput<GetLowCodeTablePadedInput> input, bool isTracking = false)
        {
            var dbSet = await BuilderQueryable(isTracking);
            var query = dbSet.WhereDynamicFilter(input.DynamicFilter);
            var data = new Page<LowCodeTableOutput>()
            {
                List = await query.OrderByDescending(a => a.Id)
                .Page(input.CurrentPage, input.PageSize)
                .Select(x => new LowCodeTableOutput
                {
                    Id = x.Id,
                    MenuParentId = x.MenuParentId,
                    MenuName = x.MenuName,
                    FunctionModule = x.FunctionModule,
                    LowCodeTableName = x.LowCodeTableName,
                    Description = x.Description,
                    CreationTime = x.CreationTime,
                    Taxon = x.Taxon
                })
                .ToListAsync(),
                Total = await query.CountAsync()
            };
            return data;
        }
    }
}
