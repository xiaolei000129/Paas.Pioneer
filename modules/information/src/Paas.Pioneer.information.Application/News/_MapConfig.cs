using AutoMapper;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.News.Dto.Output;
using Paas.Pioneer.Information.Domain.News;

namespace Paas.Pioneer.Information.Application.News
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