using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Tenant
{
    public interface ITenantService : IApplicationService
    {
        Task<ResponseOutput<TenantGetOutput>> GetAsync(Guid id);

        Task<ResponseOutput<Page<GetTenantPageListOutput>>> GetPageListAsync(PageInput<GetTenantsInput> input);

        Task<IResponseOutput> AddAsync(TenantAddInput input);

        Task<IResponseOutput> UpdateAsync(TenantUpdateInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> SoftDeleteAsync(Guid id);

        Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}
