using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Position.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;

namespace Paas.Pioneer.Admin.Core.Application.Personnel.Position
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            //新增
            CreateMap<PositionAddInput, Pe_PositionEntity>();
            //修改
            CreateMap<PositionUpdateInput, Pe_PositionEntity>();
        }
    }
}