using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTable;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.LowCodeTableConfig
{
    public class EfCoreLowCodeTableConfigRepository : BaseExtensionsRepository<Ad_LowCodeTableConfigEntity>, ILowCodeTableConfigRepository
    {
        public EfCoreLowCodeTableConfigRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
        public async Task<Page<LowCodeTableConfigOutput>> GetLowCodeTableConfigPageListAsync(PageInput<GetLowCodeTableConfigPadedInput> input, bool isTacking = false)
        {
            var dbContext = await GetDbContextAsync();

            var lowCodeTableDbSet = dbContext.Set<Ad_LowCodeTableEntity>().AsQueryable();

            if (!isTacking)
                lowCodeTableDbSet = lowCodeTableDbSet.AsNoTracking();

            var lowCodeTableConfigDbSet = await BuilderQueryable(isTacking);

            var query = from lowCodeTable in lowCodeTableDbSet
                        join lowCodeTableConfig in lowCodeTableConfigDbSet.WhereDynamicFilter(input.DynamicFilter)
                        on lowCodeTable.Id equals lowCodeTableConfig.LowCodeTableId
                        select new LowCodeTableConfigOutput
                        {
                            Id = lowCodeTableConfig.Id,
                            Description = lowCodeTableConfig.Description,
                            IsNullable = lowCodeTableConfig.IsNullable,
                            LowCodeTableId = lowCodeTableConfig.LowCodeTableId,
                            ColumnName = lowCodeTableConfig.ColumnName,
                            LowCodeTableName = lowCodeTable.LowCodeTableName
                        };
            var data = new Page<LowCodeTableConfigOutput>()
            {
                List = await query.OrderByDescending(a => a.Id)
                        .Page(input.CurrentPage, input.PageSize)
                        .ToListAsync(),
                Total = await query.CountAsync()
            };
            return data;
        }
    }
}
