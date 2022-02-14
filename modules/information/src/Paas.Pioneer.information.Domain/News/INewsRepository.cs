using Paas.Pioneer.Information.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Information.Domain.News
{
    public interface INewsRepository : IRepository<Information_NewsEntity, Guid>, IBaseExtensionRepository<Information_NewsEntity>
    {

    }
}
