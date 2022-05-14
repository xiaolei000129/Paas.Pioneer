using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Domain.BaseExtensions;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Input;

namespace Paas.Pioneer.Information.Domain.News
{
    public interface INewsRepository : IRepository<Information_NewsEntity, Guid>, IBaseExtensionRepository<Information_NewsEntity>
    {
        Task<Page<GetNewsPageListOutput>> GetPageListAsync(PageInput<GetNewsPageListInput> input);
    }
}
