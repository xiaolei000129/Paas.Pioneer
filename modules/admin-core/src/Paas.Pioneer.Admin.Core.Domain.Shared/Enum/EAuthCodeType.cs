using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 短信类型
    /// </summary>
    public enum EAuthCodeType
    {
        /// <summary>
        /// 注册
        /// </summary>
        [Description("注册")]
        Register = 1,

        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        Login = 2,

        /// <summary>
        /// 修改密码
        /// </summary>
        [Description("修改密码")]
        UpdatePassword = 3,

        /// <summary>
        /// 绑定手机号
        /// </summary>
        [Description("绑定手机号")]
        BindPhone = 4,

        /// <summary>
        /// 设置支付密码
        /// </summary>
        [Description("设置支付密码")]
        SetPayPassword = 5,

        /// <summary>
        /// 修改支付密码
        /// </summary>
        [Description("修改支付密码")]
        UpdatePayPassword = 6,

    }
}
