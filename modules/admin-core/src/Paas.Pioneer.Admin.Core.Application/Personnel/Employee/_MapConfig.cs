using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Employee;

namespace Paas.Pioneer.Admin.Core.Application.Personnel.Employee
{
    /// <summary>
    /// 映射配置
    /// 双向映射 .ReverseMap()
    /// </summary>
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            //新增
            CreateMap<EmployeeAddInput, Pe_EmployeeEntity>();

            //修改
            CreateMap<EmployeeUpdateInput, Pe_EmployeeEntity>();

            //查询
            CreateMap<Pe_EmployeeEntity, EmployeeGetOutput>();

            //查询
            CreateMap<Pe_EmployeeEntity, EmployeeGetOutput>();

            CreateMap<Pe_EmployeeEntity, EmployeeListOutput>();
        }
    }
}