using System;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Output
{
    public class GetTenantPageListOutput: TenantDto
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}