using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 栅格类型
    /// </summary>
    public enum ECommonGridType
    {
        /// <summary>
        /// 小程序
        /// </summary>
        [Description("小程序")]
        MiniProgram = 1,

        /// <summary>
        /// H5链接
        /// </summary>
        [Description("H5链接")]
        H5 = 2,

        /// <summary>
        /// View本地页面
        /// </summary>
        [Description("本地页面")]
        View = 3
    }
}
