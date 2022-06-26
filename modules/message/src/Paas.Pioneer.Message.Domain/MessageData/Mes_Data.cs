using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Message.Domain.MessageData
{
    /// <summary>
    /// 消息表
    /// </summary>
    [Table("Mes_Data")]
    [Comment("消息表")]
    [Index(nameof(SendId), Name = "IDX_SendId")]
    [Index(nameof(ReceiveId), Name = "IDX_ReceiveId")]
    public class Mes_Data : BaseEntityCore
    {
        /// <summary>
        /// 发送Id
        /// </summary>
        [Comment("发送Id")]
        [Column("SendId", TypeName = "char(36)")]
        public Guid SendId { get; set; }

        /// <summary>
        /// 接收Id
        /// </summary>
        [Comment("接收Id")]
        [Column("ReceiveId", TypeName = "char(36)")]
        public Guid ReceiveId { get; set; }
    }
}
