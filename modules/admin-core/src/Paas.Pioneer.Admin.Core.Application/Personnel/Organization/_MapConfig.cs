using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Organization.Dto.Input;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Organization;

namespace Paas.Pioneer.Admin.Core.Application.Personnel.Organization
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            //新增
            CreateMap<OrganizationAddInput, Pe_OrganizationEntity>();
            //修改
            CreateMap<OrganizationUpdateInput, Pe_OrganizationEntity>();
        }
    }
}