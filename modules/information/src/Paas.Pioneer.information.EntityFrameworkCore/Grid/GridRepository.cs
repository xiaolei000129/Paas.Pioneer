using Paas.Pioneer.Information.Domain.Grid;
using Paas.Pioneer.Information.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.Grid
{
    public class EfCoreGridRepository : BaseExtensionsRepository<Information_GridEntity>, IGridRepository
    {
        public EfCoreGridRepository(IDbContextProvider<InformationsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

