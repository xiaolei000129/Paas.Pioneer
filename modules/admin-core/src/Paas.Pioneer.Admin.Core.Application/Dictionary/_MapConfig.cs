using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;

namespace Paas.Pioneer.Admin.Core.Application.Dictionary
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_DictionaryEntity, GetDictionaryOutput>();
            CreateMap<DictionaryAddInput, Ad_DictionaryEntity>();
            CreateMap<DictionaryUpdateInput, Ad_DictionaryEntity>();
        }
    }
}
