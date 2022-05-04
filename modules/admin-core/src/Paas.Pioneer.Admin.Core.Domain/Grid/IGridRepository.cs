using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Domain.Grid
{
    public interface IGridRepository : IRepository<Information_GridEntity, Guid>, IBaseExtensionRepository<Information_GridEntity>
    {
        Task<Page<GetGridPageListOutput>> GetPageListAsync(PageInput<GetGridPageListInput> input);
    }
}
