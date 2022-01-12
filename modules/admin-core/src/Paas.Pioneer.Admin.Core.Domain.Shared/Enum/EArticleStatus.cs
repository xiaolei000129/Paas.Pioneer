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
    public enum EArticleStatus
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
        success = 1
    }
}
