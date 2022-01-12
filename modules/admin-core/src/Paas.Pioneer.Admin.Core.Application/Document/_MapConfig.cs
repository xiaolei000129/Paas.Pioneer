using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Document;
using Paas.Pioneer.Admin.Core.Domain.DocumentImage;

namespace Paas.Pioneer.Admin.Core.Application.Document
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<DocumentAddGroupInput, Ad_DocumentEntity>();
            CreateMap<DocumentAddMenuInput, Ad_DocumentEntity>();
            CreateMap<DocumentAddImageInput, Ad_DocumentEntity>();
            CreateMap<DocumentUpdateGroupInput, Ad_DocumentEntity>();
            CreateMap<DocumentUpdateMenuInput, Ad_DocumentEntity>();
            CreateMap<DocumentUpdateContentInput, Ad_DocumentEntity>();

            CreateMap<Ad_DocumentEntity, DocumentListOutput>();
            CreateMap<Ad_DocumentEntity, DocumentGetGroupOutput>();
            CreateMap<Ad_DocumentEntity, DocumentGetMenuOutput>();
            CreateMap<Ad_DocumentEntity, DocumentGetContentOutput>();

            CreateMap<DocumentAddImageInput, Ad_DocumentImageEntity>();
        }
    }
}
