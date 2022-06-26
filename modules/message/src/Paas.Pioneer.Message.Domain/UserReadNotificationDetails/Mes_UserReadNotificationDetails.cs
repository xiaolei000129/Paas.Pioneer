using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Message.Domain.UserReadNotificationDetails
{
    /// <summary>
    /// 用户阅读通知详情
    /// </summary>
    [Comment("用户阅读通知详情")]
    [Table("Mes_UserReadNotificationDetail")]
    [Index(nameof(NotificationId), Name = "IDX_NotificationId")]
    [Index(nameof(NotificationId), nameof(UserId), Name = "IDX_NotificationId_UserId")]
    public class Mes_UserReadNotificationDetails : BaseEntityNotTenantCore
    {
        /// <summary>
        /// 通知Id
        /// </summary>
        [Comment("通知Id")]
        [Column("NotificationId", TypeName = "char(36)")]
        public Guid NotificationId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        [Comment("用户Id")]
        [Column("UserId", TypeName = "char(36)")]
        public Guid UserId { get; set; }

        /// <summary>
        /// 是否阅读
        /// </summary>
        [Comment("是否阅读")]
        public bool IsRead { get; set; }
    }
}
