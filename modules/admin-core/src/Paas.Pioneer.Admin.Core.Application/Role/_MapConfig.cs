using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Role
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_RoleEntity, RoleListOutput>();
            CreateMap<Ad_RoleEntity, RoleGetOutput>();

            CreateMap<RoleAddInput, Ad_RoleEntity>();
            CreateMap<RoleUpdateInput, Ad_RoleEntity>();
        }
    }
}
