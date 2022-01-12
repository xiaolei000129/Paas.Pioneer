using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 请求响应码
    /// </summary>
    public enum EResponseType
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        [Description("请求成功")]
        Succees = 0,
        /// <summary>
        /// 请求失败
        /// </summary>
        [Description("请求失败")]
        Fail = 500,
    }
}
