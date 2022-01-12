using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.RolePermission
{
    /// <summary>
    /// 角色权限
    /// </summary>
    [Table("Ad_Role_Permission")]
    [Comment("角色权限表")]
    [Index(nameof(RoleId), Name = "IDX_RoleId")]
    [Index(nameof(PermissionId), Name = "IDX_PermissionId")]
    public class Ad_RolePermissionEntity : BaseEntityNotTenantCore
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Comment("角色Id")]
        [Column("RoleId", TypeName = "char(36)")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>
        [Comment("权限Id")]
        [Column("PermissionId", TypeName = "char(36)")]
        public Guid PermissionId { get; set; }

    }
}
