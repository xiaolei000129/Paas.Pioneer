using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType
{
    public interface IDictionaryTypeService : IApplicationService
    {
        Task<ResponseOutput<DictionaryTypeGetOutput>> GetAsync(Guid id);

        Task<ResponseOutput<Page<DictionaryTypeOutput>>> GetPageListAsync(PageInput<DictionaryTypeInput> model);

        Task<IResponseOutput> AddAsync(DictionaryTypeAddInput input);

        Task<IResponseOutput> UpdateAsync(DictionaryTypeUpdateInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}