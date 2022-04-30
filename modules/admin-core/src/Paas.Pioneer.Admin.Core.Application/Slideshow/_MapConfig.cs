using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.Slideshow;

namespace Paas.Pioneer.Admin.Core.Application.Slideshow
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