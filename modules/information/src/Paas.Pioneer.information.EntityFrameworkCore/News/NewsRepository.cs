using Paas.Pioneer.Information.Domain.News;
using Paas.Pioneer.Information.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.News
{
    public class EfCoreNewsRepository : BaseExtensionsRepository<Information_NewsEntity>, INewsRepository
    {
        public EfCoreNewsRepository(IDbContextProvider<InformationsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

