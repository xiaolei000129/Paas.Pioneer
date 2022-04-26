using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Dictionary
{
    public class EfCoreDictionaryRepository : BaseExtensionsRepository<Ad_DictionaryEntity>, IDictionaryRepository
    {
        public EfCoreDictionaryRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Page<DictionaryPageListOutput>> GetPageListAsync(PageInput<DictionaryInput> input, bool isTracking = false)
        {
            var dbSet = await BuilderQueryable(isTracking);
            var key = input.Filter?.Name;
            var dictionaryTypeId = input.Filter?.DictionaryTypeId;
            var data = dbSet
            .WhereIf(dictionaryTypeId.HasValue && dictionaryTypeId != Guid.Empty, a => a.DictionaryTypeId == dictionaryTypeId)
            .WhereIf(!key.IsNullOrEmpty(), a => a.Name.Contains(key) || a.Code.Contains(key)).AsNoTracking();

            var pageList = new Page<DictionaryPageListOutput>()
            {
                List = await data.OrderByDescending(c => c.CreationTime).Page(input.CurrentPage, input.PageSize).Select(x => new DictionaryPageListOutput()
                {
                    Id = x.Id,
                    Code = x.Code,
                    CreationTime = x.CreationTime,
                    CreatorId = x.CreatorId,
                    Description = x.Description,
                    DictionaryTypeId = x.DictionaryTypeId,
                    Enabled = x.Enabled,
                    LastModificationTime = x.LastModificationTime,
                    LastModifierId = x.LastModifierId,
                    Name = x.Name,
                    Sort = x.Sort,
                    Value = x.Value,
                }).ToListAsync(),
                Total = await data.CountAsync()
            };
            return pageList;
        }
    }
}
