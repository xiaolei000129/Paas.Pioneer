using AutoMapper;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Information.Domain.Slideshow;

namespace Paas.Pioneer.Information.Application.Slideshow
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Information_SlideshowEntity, GetSlideshowOutput>();

            CreateMap<AddSlideshowInput, Information_SlideshowEntity>();
            CreateMap<UpdateSlideshowInput, Information_SlideshowEntity>();
        }
    }
}