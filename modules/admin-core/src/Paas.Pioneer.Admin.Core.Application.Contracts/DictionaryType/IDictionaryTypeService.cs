using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType
{
    public interface IDictionaryTypeService : IApplicationService
    {
        Task<DictionaryTypeGetOutput> GetAsync(Guid id);

        Task<Page<DictionaryTypeOutput>> GetPageListAsync(PageInput<DictionaryTypeInput> model);

        Task AddAsync(DictionaryTypeAddInput input);

        Task UpdateAsync(DictionaryTypeUpdateInput input);

        Task DeleteAsync(Guid id);

        Task BatchSoftDeleteAsync(IEnumerable<Guid> ids);

        Task<List<GetDictionaryOutput>> GetCodeListAsync(GetCodeListInput input);
    }
}