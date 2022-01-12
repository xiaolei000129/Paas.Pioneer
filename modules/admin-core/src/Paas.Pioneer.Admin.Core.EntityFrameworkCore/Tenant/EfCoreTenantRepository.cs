using Paas.Pioneer.Admin.Core.Domain.Tenant;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Tenant
{

    public class EfCoreTenantRepository : BaseExtensionsRepository<Volo.Abp.TenantManagement.Tenant>, ITenantRepository
    {
        public EfCoreTenantRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
