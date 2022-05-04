using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.Comment;

namespace Paas.Pioneer.Admin.Core.Application.Comment
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Information_CommentEntity, GetCommentOutput>();

            CreateMap<AddCommentInput, Information_CommentEntity>();
            CreateMap<UpdateCommentInput, Information_CommentEntity>();
        }
    }
}