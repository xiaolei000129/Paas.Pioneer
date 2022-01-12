using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.TenantPermission
{
    /// <summary>
    /// 租户权限
    /// </summary>
	[Table("Ad_Tenant_Permission")]
    [Comment("租户权限表")]
    [Index(nameof(PermissionId), Name = "IDX_PermissionId")]
    public class Ad_TenantPermissionEntity : BaseEntityCore
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        [Comment("权限Id")]
        [Column("PermissionId", TypeName = "char(36)")]
        public Guid PermissionId { get; set; }
    }
}
