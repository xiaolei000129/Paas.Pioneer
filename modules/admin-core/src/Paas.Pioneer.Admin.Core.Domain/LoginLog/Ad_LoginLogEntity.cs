using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.LoginLog
{
    /// <summary>
    /// 登录日志
    /// </summary>
	[Table("Ad_Login_Log")]
    [Comment("登录日志表")]
    public class Ad_LoginLogEntity : BaseEntity
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [Comment("昵称")]
        [Column("NickName", TypeName = "varchar(50)")]
        public string NickName { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        [Comment("IP")]
        [Column("IP", TypeName = "varchar(100)")]
        public string IP { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        [Comment("浏览器")]
        [Column("Browser", TypeName = "varchar(100)")]
        public string Browser { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        [Comment("操作系统")]
        [Column("Os", TypeName = "varchar(100)")]
        public string Os { get; set; }

        /// <summary>
        /// 设备
        /// </summary>
        [Comment("设备")]
        [Column("Device", TypeName = "varchar(50)")]
        public string Device { get; set; }

        /// <summary>
        /// 浏览器信息
        /// </summary>
        [Comment("浏览器信息")]
        [Column("BrowserInfo", TypeName = "longtext")]
        public string BrowserInfo { get; set; }

        /// <summary>
        /// 耗时（毫秒）
        /// </summary>
        [Comment("耗时（毫秒）")]
        [Column("ElapsedMilliseconds", TypeName = "bigint")]
        public long ElapsedMilliseconds { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        [Comment("操作状态")]
        [Column("Status")]
        public bool Status { get; set; }

        /// <summary>
        /// 操作消息
        /// </summary>
        [Comment("操作消息")]
        [Column("Msg", TypeName = "varchar(500)")]
        public string Msg { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        [Comment("操作结果")]
        [Column("Result", TypeName = "longtext")]
        public string Result { get; set; }
    }
}