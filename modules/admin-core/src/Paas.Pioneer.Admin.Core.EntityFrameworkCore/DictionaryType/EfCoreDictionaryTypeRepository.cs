using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.DictionaryType;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.DictionaryType
{
    public class EfCoreDictionaryTypeRepository : BaseExtensionsRepository<Ad_DictionaryTypeEntity>, IDictionaryTypeRepository
    {
        public EfCoreDictionaryTypeRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Page<DictionaryTypeOutput>> GetPageListAsync(PageInput<DictionaryTypeInput> model, bool isTracking = false)
        {
            var dbSet = await BuilderQueryable(isTracking);

            var key = model.Filter?.Name;
            var list = dbSet
            .WhereIf(!key.IsNullOrEmpty(), a => a.Name.Contains(key) || a.Code.Contains(key));

            var data = new Page<DictionaryTypeOutput>()
            {
                List = await list.OrderByDescending(x => x.CreationTime).Page(model.CurrentPage, model.PageSize).Select(x => new DictionaryTypeOutput()
                {
                    Id = x.Id,
                    Code = x.Code,
                    CreationTime = x.CreationTime,
                    CreatorId = x.CreatorId,
                    Description = x.Description,
                    Enabled = x.Enabled,
                    LastModificationTime = x.LastModificationTime,
                    LastModifierId = x.LastModifierId,
                    Name = x.Name,
                    Sort = x.Sort,
                }).ToListAsync(),
                Total = await list.CountAsync()
            };
            return data;
        }
    }
}
