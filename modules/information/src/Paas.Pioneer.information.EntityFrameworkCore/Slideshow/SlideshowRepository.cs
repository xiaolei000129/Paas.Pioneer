using Paas.Pioneer.Information.Domain.Slideshow;
using Paas.Pioneer.Information.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.Slideshow
{
    public class EfCoreSlideshowRepository : BaseExtensionsRepository<Information_SlideshowEntity>, ISlideshowRepository
    {
        public EfCoreSlideshowRepository(IDbContextProvider<InformationsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

