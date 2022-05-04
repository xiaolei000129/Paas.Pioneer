using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.Grid;

namespace Paas.Pioneer.Admin.Core.Application.Grid
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Information_GridEntity, GetGridOutput>();

            CreateMap<AddGridInput, Information_GridEntity>();
            CreateMap<UpdateGridInput, Information_GridEntity>();
        }
    }
}