using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
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
        Task<ResponseOutput<ViewGetOutput>> GetAsync(Guid id);

        Task<ResponseOutput<List<ViewGetOutput>>> GetListAsync(string key);

        Task<ResponseOutput<Page<ViewGetOutput>>> GetPageListAsync(PageInput<ViewModel> model);

        Task<IResponseOutput> AddAsync(ViewAddInput input);

        Task<IResponseOutput> UpdateAsync(ViewUpdateInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> BatchSoftDeleteAsync(Guid[] ids);
    }
}