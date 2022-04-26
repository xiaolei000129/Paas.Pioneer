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
        Task<ResponseOutput<PositionDataOutput>> GetAsync(Guid id);

        Task<ResponseOutput<Page<PositionListOutput>>> GetPageListAsync(PageInput<PositionDataOutput> input);

        Task<IResponseOutput> AddAsync(PositionAddInput input);

        Task<IResponseOutput> UpdateAsync(PositionUpdateInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> BatchSoftDeleteAsync(Guid[] ids);
    }
}