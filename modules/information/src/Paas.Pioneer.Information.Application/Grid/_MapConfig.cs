using AutoMapper;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Output;
using Paas.Pioneer.Information.Domain.Grid;

namespace Paas.Pioneer.Information.Application.Grid
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