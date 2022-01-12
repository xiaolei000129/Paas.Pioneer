using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 任务大厅枚举
    /// </summary>
    public enum ETaskHallType
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        ALL = 1,

        /// <summary>
        /// 最新发布
        /// </summary>
        [Description("最新发布")]
        LatestPush = 2,

        /// <summary>
        /// 关注商家
        /// </summary>
        [Description("关注商家")]
        AttentionMerchant = 3,

        /// <summary>
        /// 高价
        /// </summary>
        [Description("高价")]
        HighPrice = 4,

        /// <summary>
        /// 认领量/时间（当前时间-发布时间）
        /// </summary>
        [Description("认领量/时间（当前时间-发布时间）")]
        FireStorm = 5,
    }
}
