using Paas.Pioneer.Information.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Information.Domain.Slideshow
{
    public interface ISlideshowRepository : IRepository<Information_SlideshowEntity, Guid>, IBaseExtensionRepository<Information_SlideshowEntity>
    {

    }
}
