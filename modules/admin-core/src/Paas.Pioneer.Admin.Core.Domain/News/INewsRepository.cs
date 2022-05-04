using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Input;

namespace Paas.Pioneer.Admin.Core.Domain.News
{
    public interface INewsRepository : IRepository<Information_NewsEntity, Guid>, IBaseExtensionRepository<Information_NewsEntity>
    {
        Task<Page<GetNewsPageListOutput>> GetPageListAsync(PageInput<GetNewsPageListInput> input);
    }
}
