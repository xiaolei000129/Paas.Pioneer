using Paas.Pioneer.Admin.Core.Application.Contracts.{{ model.taxon }}.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{ model.taxon }}.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.{{ model.taxon }}
{
    public interface I{{ model.taxon }}Repository : IRepository<{{ model.low_code_table_name }}Entity, Guid>, IBaseExtensionRepository<{{ model.low_code_table_name }}Entity>
    {

    }
}
