using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable
{
    public interface ILowCodeTableService
    {
        Task<IResponseOutput> AddLowCodeTableAsync(AddLowCodeTableInput input);

        Task<IResponseOutput> EditLowCodeTableAsync(EditLowCodeTableInput input);

        Task<IResponseOutput> DelLowCodeTableAsync(Guid id);

        Task<IResponseOutput<LowCodeTableOutput>> GetAsync(Guid id);

        Task<IResponseOutput> BatchDeleteAsync(IEnumerable<Guid> ids);

        Task<IResponseOutput<IEnumerable<LowCodeTableEntityOutput>>> GetTableEntityListAsync();

        Task<IResponseOutput<List<LowCodeTableColumnOutput>>> GetColumnListByTableNameAsync(Guid id);

        Task<ResponseOutput<Page<LowCodeTableOutput>>> GetLowCodeTablePageListAsync(PageInput<GetLowCodeTablePadedInput> input);

        Task<IResponseOutput> GenerateCodeAsync(Guid id);
    }
}
