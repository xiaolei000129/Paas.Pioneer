using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System.Collections.Generic;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Domain.DictionaryType
{
    public interface IDictionaryTypeRepository : IRepository<Ad_DictionaryTypeEntity, Guid>, IBaseExtensionRepository<Ad_DictionaryTypeEntity>
    {
        Task<Page<DictionaryTypeOutput>> GetPageListAsync(PageInput<DictionaryTypeInput> model, bool isTracking = false);

        Task<List<GetDictionaryOutput>> GetCodeListAsync(GetCodeListInput input);
    }
}
