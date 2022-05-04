using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position
{
    public interface IPositionService
    {
        Task<PositionDataOutput> GetAsync(Guid id);

        Task<Page<PositionListOutput>> GetPageListAsync(PageInput<PositionDataOutput> input);

        Task AddAsync(PositionAddInput input);

        Task UpdateAsync(PositionUpdateInput input);

        Task DeleteAsync(Guid id);

        Task BatchSoftDeleteAsync(Guid[] ids);
    }
}