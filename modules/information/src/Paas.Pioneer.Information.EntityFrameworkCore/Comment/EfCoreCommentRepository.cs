using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Information.Domain.Comment;
using Paas.Pioneer.Information.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.Comment
{
    public class EfCoreCommentRepository : BaseExtensionsRepository<Information_CommentEntity>, ICommentRepository
    {
        public EfCoreCommentRepository(IDbContextProvider<InformationsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

