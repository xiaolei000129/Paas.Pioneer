using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig
{
    public interface ILowCodeTableConfigRepository : IRepository<Ad_LowCodeTableConfigEntity, Guid>, IBaseExtensionRepository<Ad_LowCodeTableConfigEntity>
    {
        Task<Page<LowCodeTableConfigOutput>> GetLowCodeTableConfigPageListAsync(PageInput<GetLowCodeTableConfigPadedInput> input, bool isTacking = false);
    }
}
