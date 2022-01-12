using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 消息来源类型
    /// </summary>
    public enum EMessagePurposeType
    {
        /// <summary>
		/// 审核任务通过通知
		/// </summary>
		[Description("审核任务通过通知")]
        AuditMessionPassNotice = 1,

        /// <summary>
        /// 审核任务拒绝通知
        /// </summary>
        [Description("审核任务拒绝通知")]
        AuditMessionNoPassNotice = 2,
    }
}
