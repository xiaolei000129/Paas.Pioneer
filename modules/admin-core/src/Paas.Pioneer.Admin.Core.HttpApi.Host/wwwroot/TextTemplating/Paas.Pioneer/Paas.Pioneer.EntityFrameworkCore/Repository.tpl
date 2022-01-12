using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{ model.taxon }}.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{ model.taxon }}.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.{{ model.taxon }};
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.{{ model.taxon }}
{
    public class EfCore{{ model.taxon }}Repository : BaseExtensionsRepository<{{ model.low_code_table_name }}Entity>, I{{ model.taxon }}Repository
    {
        public EfCore{{ model.taxon }}Repository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

