using Paas.Pioneer.Admin.Core.Domain.Document;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Document
{
    public class EfCoreDocumentRepository : BaseExtensionsRepository<Ad_DocumentEntity>, IDocumentRepository
    {
        public EfCoreDocumentRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

    }
}
