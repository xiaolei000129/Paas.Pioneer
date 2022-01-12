using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.LowCodeTable
{
    public interface ILowCodeTableRepository : IRepository<Ad_LowCodeTableEntity, Guid>, IBaseExtensionRepository<Ad_LowCodeTableEntity>
    {
        Task<Page<LowCodeTableOutput>> GetLowCodeTablePageListAsync(PageInput<GetLowCodeTablePadedInput> input, bool isTracking = false);

    }
}
