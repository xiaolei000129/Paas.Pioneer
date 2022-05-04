using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig
{
    public interface ILowCodeTableConfigService
    {
        Task AddLowCodeTableConfigAsync(AddLowCodeTableConfigInput input);

        Task EditLowCodeTableConfigAsync(List<EditLowCodeTableConfigInput> inputList);

        Task DelLowCodeTableConfigAsync(Guid id);

        Task<Page<LowCodeTableConfigOutput>> GetLowCodeTableConfigPageListAsync(PageInput<GetLowCodeTableConfigPadedInput> input);
    }
}
