namespace Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output
{
    /// <summary>
    /// 登录成功返回信息
    /// </summary>
    public class LoginSuccessOutput
    {
        /// <summary>
        /// 用户令牌
        /// </summary>
        public string token { get; set; }
    }
}
