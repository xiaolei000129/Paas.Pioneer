using Paas.Pioneer.Information.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Information.Domain.Comment
{
    public interface ICommentRepository : IRepository<Information_CommentEntity, Guid>, IBaseExtensionRepository<Information_CommentEntity>
    {

    }
}
