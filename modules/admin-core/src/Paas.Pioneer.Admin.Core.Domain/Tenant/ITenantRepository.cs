using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Tenant
{

    public interface ITenantRepository : IRepository<Volo.Abp.TenantManagement.Tenant, Guid>, IBaseExtensionRepository<Volo.Abp.TenantManagement.Tenant>
    {

    }
}
