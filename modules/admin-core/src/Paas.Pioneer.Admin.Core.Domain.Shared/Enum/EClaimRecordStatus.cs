using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 任务领取状态 1未领取 2已领取未完成 3已完成
    /// </summary>
    public enum EClaimRecordStatus
    {
        /// <summary>
        /// 未领取
        /// </summary>
        [Description("未领取")]
        NoClaim = 1,

        /// <summary>
        /// 已领取未完成
        /// </summary>
        [Description("已领取未完成")]
        Underway = 2,

        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        Audit = 3,

        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        Finish = 4,

        /// <summary>
        /// 异议
        /// </summary>
        [Description("异议")]
        Objection = 5,

        /// <summary>
        /// 平台介入
        /// </summary>
        [Description("平台介入")]
        Intervene = 6,
        /// <summary>
        /// 任务作废
        /// </summary>
        [Description("任务作废")]
        Abandoned = 7
    }
}
