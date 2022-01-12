using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 审核状态
    /// </summary>
    public enum EAuditStatus
    {
        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        audit = 0,

        /// <summary>
        /// 审核通过
        /// </summary>
        [Description("审核通过")]
        success = 1,
        /// <summary>
        /// 审核拒绝
        /// </summary>
        [Description("审核拒绝")]
        fail = 2
    }

    /// <summary>
    /// 实名审核状态
    /// </summary>
    public enum EAuditRealStatus
    {
        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        audit = 0,

        /// <summary>
        /// 审核通过
        /// </summary>
        [Description("审核通过")]
        success = 1,
        /// <summary>
        /// 审核拒绝
        /// </summary>
        [Description("审核拒绝")]
        fail = 2,
        /// <summary>
        /// 未实名
        /// </summary>
        [Description("未实名")]
        Nodata = 3
    }
}
