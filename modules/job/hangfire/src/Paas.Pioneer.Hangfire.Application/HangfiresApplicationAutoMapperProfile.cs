using AutoMapper;
using Paas.Pioneer.Admin.Core.Domain.Api;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Paas.Pioneer.Admin.Core.Domain.DictionaryType;
using Paas.Pioneer.Admin.Core.Domain.Document;
using Paas.Pioneer.Admin.Core.Domain.DocumentImage;
using Paas.Pioneer.Admin.Core.Domain.LoginLog;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTable;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.PermissionApi;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Employee;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Organization;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Admin.Core.Domain.TenantPermission;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Admin.Core.Domain.View;
using Paas.Pioneer.Hangfire.Domain.Entitys;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Hangfire.Application
{
    public class HangfiresApplicationAutoMapperProfile : Profile
    {
        public HangfiresApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Ad_Api, Ad_ApiEntity>();
            CreateMap<Ad_Dictionary, Ad_DictionaryEntity>();
            CreateMap<Ad_DictionaryType, Ad_DictionaryTypeEntity>();
            CreateMap<Ad_Document, Ad_DocumentEntity>();
            CreateMap<Ad_DocumentImage, Ad_DocumentImageEntity>();
            CreateMap<Ad_LoginLog, Ad_LoginLogEntity>();
            CreateMap<Ad_LowCodeTable, Ad_LowCodeTableEntity>();
            CreateMap<Ad_LowCodeTableConfig, Ad_LowCodeTableConfigEntity>();
            CreateMap<Ad_Permission, Ad_PermissionEntity>();
            CreateMap<Ad_PermissionApi, Ad_PermissionApiEntity>();
            CreateMap<Ad_Role, Ad_RoleEntity>();
            CreateMap<Ad_RolePermission, Ad_RolePermissionEntity>();
            CreateMap<Ad_Tenant, Tenant>();
            CreateMap<Tenant, Ad_Tenant>();
            CreateMap<Ad_TenantPermission, Ad_TenantPermissionEntity>();
            CreateMap<Ad_User, Ad_UserEntity>();
            CreateMap<Ad_UserRole, Ad_UserRoleEntity>();
            CreateMap<Ad_View, Ad_ViewEntity>();
            CreateMap<Pe_Employee, Ad_UserRoleEntity>();
            CreateMap<Pe_Organization, Pe_OrganizationEntity>();
            CreateMap<Pe_Position, Pe_PositionEntity>();
        }
    }
}
