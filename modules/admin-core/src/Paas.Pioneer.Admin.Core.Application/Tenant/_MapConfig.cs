using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Output;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Application.Tenant
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Volo.Abp.TenantManagement.Tenant, TenantGetOutput>();
            CreateMap<Volo.Abp.TenantManagement.Tenant, GetTenantPageListOutput>();


            CreateMap<TenantUpdateDto, Volo.Abp.TenantManagement.Tenant>();

            CreateMap<TenantAddInput, Volo.Abp.TenantManagement.Tenant>();
        }
    }
}
