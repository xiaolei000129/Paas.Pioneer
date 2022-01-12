using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.User;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Shared.Captcha;
using Paas.Pioneer.Admin.Core.Domain.Shared.Captcha.Dtos;
using Paas.Pioneer.Domain.Shared.Auth;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using Paas.Pioneer.Domain.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 授权管理
    /// </summary>
    [Route("api/admin/[controller]")]
    [Authorize]
    public class AuthController : AbpControllerBase
    {
        private readonly IUserToken _userToken;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ILoginLogService _loginLogService;
        private readonly ICaptcha _captcha;
        private readonly IDataFilter _dataFilter;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="authService"></param>
        /// <param name="userService"></param>
        /// <param name="loginLogService"></param>
        /// <param name="captcha"></param>
        /// <param name="dataFilter"></param>
        public AuthController(
            IUserToken userToken,
            IAuthService authService,
            IUserService userService,
            ILoginLogService loginLogService,
            ICaptcha captcha,
            IDataFilter dataFilter)
        {
            _userToken = userToken;
            _authService = authService;
            _userService = userService;
            _loginLogService = loginLogService;
            _captcha = captcha;
            _dataFilter = dataFilter;
        }

        /// <summary>
        /// 获得token
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private ResponseOutput<LoginSuccessOutput> GetToken(ResponseOutput<AuthLoginOutput> output)
        {
            if (!output.Success)
            {
                return ResponseOutput.Error<LoginSuccessOutput>(output.Msg);
            }
            var user = output.Data;
            if (user == null)
            {
                return ResponseOutput.Error<LoginSuccessOutput>("用户信息错误");
            }
            IEnumerable<Claim> claimList = new[]
            {
                new Claim(ClaimAttributes.UserId, user.Id.ToString()),
                new Claim(ClaimAttributes.UserName, user.UserName),
                new Claim(ClaimAttributes.UserNickName, user.NickName),
                new Claim(ClaimAttributes.TenantId, user.TenantId.ToString()),
                new Claim(ClaimAttributes.TenantType, user.TenantType.ToString()),
            };
            var token = _userToken.Create(claimList);
            return ResponseOutput.Succees(new LoginSuccessOutput
            {
                token = token
            });
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="lastKey">上次验证码键</param>
        /// <returns></returns>
        [HttpGet("getVerifyCode")]
        [AllowAnonymous]
        public async Task<ResponseOutput<AuthGetVerifyCodeOutput>> GetVerifyCode(string lastKey)
        {
            return await _authService.GetVerifyCodeAsync(lastKey);
        }

        /// <summary>
        /// 获取验证数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCaptcha")]
        [AllowAnonymous]
        public async Task<ResponseOutput<CaptchaOutput>> GetCaptcha()
        {
            var data = await _captcha.GetAsync();
            return ResponseOutput.Succees(data);
        }

        /// <summary>
        /// 检查验证数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("checkCaptcha")]
        [AllowAnonymous]
        public async Task<IResponseOutput> CheckCaptcha([FromQuery] CaptchaInput input)
        {
            var result = await _captcha.CheckAsync(input);
            return ResponseOutput.Succees(result);
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <returns></returns>
        [HttpGet("getPassWordEncryptKey")]
        [AllowAnonymous]
        public async Task<ResponseOutput<GetPassWordEncryptKeyOutput>> GetPassWordEncryptKey()
        {
            return await _authService.GetPassWordEncryptKeyAsync();
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUserInfo")]
        public async Task<ResponseOutput<AuthUserInfoOutput>> GetUserInfo()
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                return await _authService.GetUserInfoAsync();
            }
        }

        /// <summary>
        /// 用户登录
        /// 根据登录信息生成Token
        /// </summary>
        /// <param name="input">登录信息</param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IResponseOutput> Login([FromBody] AuthLoginInput input)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var sw = new Stopwatch();
                sw.Start();
                var res = await _authService.LoginAsync(input);
                sw.Stop();

                #region 添加登录日志

                var loginLogAddInput = new LoginLogAddInput()
                {
                    CreatedUserName = input.UserName,
                    ElapsedMilliseconds = sw.ElapsedMilliseconds,
                    Status = res.Success,
                    Msg = res.Msg
                };

                ResponseOutput<AuthLoginOutput> output = null;
                if (res.Success)
                {
                    output = res;
                    var user = output.Data;
                    loginLogAddInput.CreatedUserId = user.Id;
                    loginLogAddInput.NickName = user.NickName;
                    loginLogAddInput.TenantId = user.TenantId;
                }

                await _loginLogService.AddAsync(loginLogAddInput);

                #endregion 添加登录日志

                if (!res.Success)
                {
                    return res;
                }

                return GetToken(output);
            }
        }

        /// <summary>
        /// 刷新Token
        /// 以旧换新
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("refresh")]
        [AllowAnonymous]
        public async Task<IResponseOutput> Refresh([BindRequired] string token)
        {
            var userClaims = _userToken.Decode(token);
            if (userClaims == null || !userClaims.Any())
            {
                return ResponseOutput.Error("错误token");
            }

            var refreshExpires = userClaims.FirstOrDefault(a => a.Type == ClaimAttributes.RefreshExpires)?.Value;
            if (refreshExpires.IsNull())
            {
                return ResponseOutput.Error("错误token");
            }

            if (refreshExpires.ToLong() <= DateTime.Now.ToTimestamp())
            {
                return ResponseOutput.Error("登录信息已过期");
            }

            var userId = userClaims.FirstOrDefault(a => a.Type == ClaimAttributes.UserId)?.Value;
            if (userId.IsNull())
            {
                return ResponseOutput.Error("登录信息已失效");
            }
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var output = await _userService.GetLoginUserAsync(Guid.Parse(userId));
                return GetToken(output);
            }
        }
    }
}
