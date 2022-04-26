using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.View
{
    /// <summary>
    /// ÊÓÍ¼·þÎñ
    /// </summary>
    public interface IViewService : IApplicationService
    {
        Task<ViewGetOutput> GetAsync(Guid id);

        Task<List<ViewGetOutput>> GetListAsync(string key);

        Task<Page<ViewGetOutput>> GetPageListAsync(PageInput<ViewModel> model);

        Task AddAsync(ViewAddInput input);

        Task UpdateAsync(ViewUpdateInput input);

        Task DeleteAsync(Guid id);

        Task BatchSoftDeleteAsync(Guid[] ids);
    }
}