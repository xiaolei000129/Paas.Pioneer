using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Tenant
{
    public interface ITenantService : IApplicationService
    {
        Task<TenantGetOutput> GetAsync(Guid id);

        Task<Page<GetTenantPageListOutput>> GetPageListAsync(PageInput<GetTenantsInput> input);

        Task AddAsync(TenantAddInput input);

        Task UpdateAsync(TenantUpdateInput input);

        Task DeleteAsync(Guid id);

        Task SoftDeleteAsync(Guid id);

        Task BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}
