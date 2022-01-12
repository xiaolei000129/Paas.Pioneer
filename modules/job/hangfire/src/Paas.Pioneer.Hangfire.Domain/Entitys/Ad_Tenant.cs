using System;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Hangfire.Domain.Entitys
{
    public class Ad_Tenant : TenantCreateDto
    {
        public Guid Id { get; set; }
    }
}
