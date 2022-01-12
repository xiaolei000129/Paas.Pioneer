using Paas.Pioneer.Admin.Core.Domain.Shared.Captcha.Dtos;
using System;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Captcha
{
    /// <summary>
    /// 验证接口
    /// </summary>
    public interface ICaptcha
    {
        /// <summary>
        /// 获得验证数据
        /// </summary>
        /// <returns></returns>
        Task<CaptchaOutput> GetAsync();

        /// <summary>
        /// 检查验证数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> CheckAsync(CaptchaInput input);
    }
}