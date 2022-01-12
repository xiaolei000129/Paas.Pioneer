using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Permission
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_PermissionEntity, PermissionListOutput>();
            CreateMap<Ad_PermissionEntity, PermissionGetDotOutput>();
            CreateMap<Ad_PermissionEntity, PermissionDataOutput>();
            CreateMap<Ad_PermissionEntity, PermissionGetGroupOutput>();
            CreateMap<Ad_PermissionEntity, PermissionGetMenuOutput>();
            CreateMap<Ad_PermissionEntity, PermissionGetApiOutput>();

            CreateMap<PermissionAddGroupInput, Ad_PermissionEntity>();
            CreateMap<PermissionAddMenuInput, Ad_PermissionEntity>();
            CreateMap<PermissionAddApiInput, Ad_PermissionEntity>();
            CreateMap<PermissionAddDotInput, Ad_PermissionEntity>();
            CreateMap<PermissionUpdateGroupInput, Ad_PermissionEntity>();
            CreateMap<PermissionUpdateMenuInput, Ad_PermissionEntity>();
            CreateMap<PermissionUpdateApiInput, Ad_PermissionEntity>();
            CreateMap<PermissionUpdateDotInput, Ad_PermissionEntity>();
        }
    }
}
