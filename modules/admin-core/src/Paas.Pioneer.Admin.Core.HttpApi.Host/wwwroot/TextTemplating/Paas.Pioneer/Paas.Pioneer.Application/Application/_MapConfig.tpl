using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.{{model.taxon}};

namespace Paas.Pioneer.Admin.Core.Application.{{model.taxon}}
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<{{ model.low_code_table_name }}, Get{{model.taxon}}Output>();

            CreateMap<Add{{model.taxon}}Input, {{ model.low_code_table_name }}>();
            CreateMap<Update{{model.taxon}}Input, {{ model.low_code_table_name }}>();
        }
    }
}