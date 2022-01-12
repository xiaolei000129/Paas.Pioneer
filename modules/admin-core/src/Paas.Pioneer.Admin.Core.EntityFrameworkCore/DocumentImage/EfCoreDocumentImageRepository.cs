using Paas.Pioneer.Admin.Core.Domain.DocumentImage;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.DocumentImage
{
    public class EfCoreDocumentImageRepository : BaseExtensionsRepository<Ad_DocumentImageEntity>, IDocumentImageRepository
    {
        public EfCoreDocumentImageRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
