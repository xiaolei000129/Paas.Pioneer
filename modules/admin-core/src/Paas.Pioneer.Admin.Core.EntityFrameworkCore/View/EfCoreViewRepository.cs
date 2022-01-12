using Paas.Pioneer.Admin.Core.Domain.View;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.View
{
    public class EfCoreViewRepository : BaseExtensionsRepository<Ad_ViewEntity>, IViewRepository
    {
        public EfCoreViewRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
