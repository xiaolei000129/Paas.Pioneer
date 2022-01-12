namespace Paas.Pioneer.Admin.Core.Domain.Shared.Captcha.Dtos
{
    /// <summary>
    /// 验证数据
    /// </summary>
    public class CaptchaOutput
    {
        /// <summary>
        /// 校验唯一标识
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}
