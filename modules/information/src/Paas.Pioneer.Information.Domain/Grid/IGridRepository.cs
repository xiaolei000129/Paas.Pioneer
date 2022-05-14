using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Domain.BaseExtensions;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Output;

namespace Paas.Pioneer.Information.Domain.Grid
{
    public interface IGridRepository : IRepository<Information_GridEntity, Guid>, IBaseExtensionRepository<Information_GridEntity>
    {
        Task<Page<GetGridPageListOutput>> GetPageListAsync(PageInput<GetGridPageListInput> input);
    }
}
