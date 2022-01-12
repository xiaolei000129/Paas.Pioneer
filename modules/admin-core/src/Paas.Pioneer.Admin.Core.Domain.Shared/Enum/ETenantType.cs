using System.ComponentModel;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 租户类型
    /// </summary>
    public enum ETenantType
    {
        /// <summary>
        /// 平台
        /// </summary>
        [Description("平台")]
        Platform = 1,

        /// <summary>
        /// 租户
        /// </summary>
        [Description("租户")]
        Tenant = 2
    }
}
