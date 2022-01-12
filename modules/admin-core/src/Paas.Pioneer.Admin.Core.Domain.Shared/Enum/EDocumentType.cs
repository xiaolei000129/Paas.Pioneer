using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 文档类型
    /// </summary>
    public enum EDocumentType
    {
        /// <summary>
        /// 分组
        /// </summary>
        [Description("分组")]
        Group = 1,

        /// <summary>
        /// Markdown文档
        /// </summary>
        [Description("Markdown文档")]
        Markdown = 2
    }
}
