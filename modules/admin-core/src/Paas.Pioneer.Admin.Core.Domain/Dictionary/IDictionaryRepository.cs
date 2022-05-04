using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Domain.Dictionary
{
    public interface IDictionaryRepository : IRepository<Ad_DictionaryEntity, Guid>, IBaseExtensionRepository<Ad_DictionaryEntity>
    {
        Task<Page<DictionaryPageListOutput>> GetPageListAsync(PageInput<DictionaryInput> input, bool isTracking = false);
    }
}
