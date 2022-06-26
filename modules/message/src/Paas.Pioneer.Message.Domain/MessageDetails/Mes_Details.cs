using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Message.Domain.MessageDetails
{
    /// <summary>
    /// 消息详情表
    /// </summary>
    [Table("Mes_Details")]
    [Comment("消息详情表")]
    [Index(nameof(MessageDataId), Name = "IDX_MessageDataId")]
    public class Mes_Details : BaseEntityNotTenantCore
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        [Comment("消息Id")]
        [Column("MessageDataId", TypeName = "char(36)")]
        public Guid MessageDataId { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [Comment("通知详情")]
        [Column("MessageContent", TypeName = "varchar(3000)")]
        public string MessageContent { get; set; }

    }
}
