using AutoMapper;
using Paas.Pioneer.Information.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Information.Domain.Comment;

namespace Paas.Pioneer.Information.Application.Comment
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