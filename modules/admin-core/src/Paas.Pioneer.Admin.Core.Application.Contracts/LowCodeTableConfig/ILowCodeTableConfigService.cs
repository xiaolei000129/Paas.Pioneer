using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig
{
    public interface ILowCodeTableConfigService
    {
        Task<IResponseOutput> AddLowCodeTableConfigAsync(AddLowCodeTableConfigInput input);

        Task<IResponseOutput> EditLowCodeTableConfigAsync(List<EditLowCodeTableConfigInput> inputList);

        Task<IResponseOutput> DelLowCodeTableConfigAsync(Guid id);

        Task<ResponseOutput<Page<LowCodeTableConfigOutput>>> GetLowCodeTableConfigPageListAsync(PageInput<GetLowCodeTableConfigPadedInput> input);
    }
}
