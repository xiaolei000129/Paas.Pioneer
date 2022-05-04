using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.News;

namespace Paas.Pioneer.Admin.Core.Application.News
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Information_NewsEntity, GetNewsOutput>();

            CreateMap<AddNewsInput, Information_NewsEntity>();
            CreateMap<UpdateNewsInput, Information_NewsEntity>();
        }
    }
}