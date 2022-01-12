using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum EPermissionType
    {
        /// <summary>
        /// 分组
        /// </summary>
        [Description("分组")]
        Group = 1,

        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu = 2,

        /// <summary>
        /// 权限点
        /// </summary>
        [Description("权限点")]
        Dot = 3
    }
}
