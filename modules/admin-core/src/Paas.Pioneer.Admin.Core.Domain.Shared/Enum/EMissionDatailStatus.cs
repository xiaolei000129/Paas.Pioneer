using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 任务审核状态
    /// </summary>
    public enum EMissionDatailStatus
    {
        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        Audit = 1,

        /// <summary>
        /// 审核通过
        /// </summary>
        [Description("审核通过")]
        AuditPass = 2,

        /// <summary>
        /// 待支付
        /// </summary>
        [Description("待支付")]
        AwaitDefray = 3,

        /// <summary>
        /// 审核拒绝
        /// </summary>
        [Description("审核拒绝")]
        AuditRefuse = 4,
    }
}
