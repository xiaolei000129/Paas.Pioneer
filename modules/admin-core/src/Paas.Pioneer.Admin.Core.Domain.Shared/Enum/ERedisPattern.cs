using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// Redis模式枚举
    /// </summary>
    public enum ERedisPattern
    {
        /// <summary>
        /// 单机
        /// </summary>
        [Description("单机模式")]
        StandAlone = 1,

        /// <summary>
        /// 读写分离模式
        /// </summary>
        [Description("读写分离模式")]
        GetOrSetProxy = 2,

        /// <summary>
        /// 哨兵模式
        /// </summary>
        [Description("哨兵模式")]
        Sentry = 3,

        /// <summary>
        /// 集群模式
        /// </summary>
        [Description("集群模式")]
        Colony = 4
    }
}
