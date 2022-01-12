using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 我的任务
    /// </summary>
    public enum EMyTaskType
    {
        /// <summary>
        /// 待提交
        /// </summary>
        [Description("待提交")]
        ToSubmit = 1,

        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        Audit = 2,

        /// <summary>
        /// 已通过
        /// </summary>
        [Description("已通过")]
        AlreadyPassed = 3,

        /// <summary>
        /// 未通过
        /// </summary>
        [Description("未通过")]
        NotPass = 4,

        /// <summary>
        /// 复审举报
        /// </summary>
        [Description("复审举报")]
        ReviewReport = 5
    }
}
