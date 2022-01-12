using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 任务认领状态
    /// </summary>
    public enum EMissionClaimRecordStatus
    {
        /// <summary>
        /// 进行中
        /// </summary>
        [Description("进行中")]
        Underway = 1,

        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        Audit = 2,

        /// <summary>
        /// 完成
        /// </summary>
        [Description("完成")]
        Finish = 3,

        /// <summary>
        /// 异议
        /// </summary>
        [Description("异议")]
        Objection = 4,

        /// <summary>
        /// 平台介入
        /// </summary>
        [Description("平台介入")]
        Intervene = 5,

        /// <summary>
        /// 任务作废
        /// </summary>
        [Description("任务作废")]
        Abandoned = 6
    }
}
