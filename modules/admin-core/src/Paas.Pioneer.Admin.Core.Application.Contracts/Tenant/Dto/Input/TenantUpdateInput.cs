using System;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Input
{
    /// <summary>
    /// 修改
    /// </summary>
    public class TenantUpdateInput : TenantUpdateDto
    {
        /// <summary>
        /// 接口Id
        /// </summary>
        public Guid Id { get; set; }
    }
}