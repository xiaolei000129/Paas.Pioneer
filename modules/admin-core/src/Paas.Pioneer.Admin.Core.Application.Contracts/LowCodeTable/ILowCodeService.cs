using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable
{
    public interface ILowCodeTableService
    {
        Task AddLowCodeTableAsync(AddLowCodeTableInput input);

        Task EditLowCodeTableAsync(EditLowCodeTableInput input);

        Task DelLowCodeTableAsync(Guid id);

        Task<LowCodeTableOutput> GetAsync(Guid id);

        Task BatchDeleteAsync(IEnumerable<Guid> ids);

        Task<IEnumerable<LowCodeTableEntityOutput>> GetTableEntityListAsync();

        Task<List<LowCodeTableColumnOutput>> GetColumnListByTableNameAsync(Guid id);

        Task<Page<LowCodeTableOutput>> GetLowCodeTablePageListAsync(PageInput<GetLowCodeTablePadedInput> input);

        Task GenerateCodeAsync(Guid id);

        Task GenerateViewAsync(Guid id);
    }
}
