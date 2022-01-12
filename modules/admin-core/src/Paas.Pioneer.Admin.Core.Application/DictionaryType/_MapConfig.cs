using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Paas.Pioneer.Admin.Core.Domain.DictionaryType;

namespace Paas.Pioneer.Admin.Core.Application.DictionaryType
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_DictionaryTypeEntity, DictionaryTypeGetOutput>();
            CreateMap<Ad_DictionaryEntity, DictionaryPageListOutput>();
            CreateMap<Ad_DictionaryTypeEntity, DictionaryTypeOutput>();

            CreateMap<DictionaryTypeAddInput, Ad_DictionaryTypeEntity>();
            CreateMap<DictionaryTypeUpdateInput, Ad_DictionaryTypeEntity>();
        }
    }
}
