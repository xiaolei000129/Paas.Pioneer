using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using Paas.Pioneer.Message.Domain.Shared.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Message.Domain.Notification
{
    /// <summary>
    /// 通知
    /// </summary>
    [Comment("通知")]
    [Table("Mes_Notification")]
    [Index(nameof(NotificationType), Name = "IDX_NotificationType")]
    public class Mes_Notification : BaseEntityCore
    {
        /// <summary>
        /// 通知标题
        /// </summary>
        [Comment("通知标题")]
        [Column("Title", TypeName = "varchar(50)")]
        public string Title { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        [Comment("通知类型")]
        [Column("NotificationType", TypeName = "int")]
        public ENotificationType NotificationType { get; set; }

        /// <summary>
        /// 通知详情
        /// </summary>
        [Comment("通知详情")]
        [Column("Detail", TypeName = "text")]
        public string Detail { get; set; }
    }
}
