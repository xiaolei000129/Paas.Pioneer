using Microsoft.Extensions.Options;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey;
using Paas.Pioneer.Admin.Core.Domain.Tenant;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.View;
using Paas.Pioneer.Domain.Shared.Auth;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Lazy.SlideCaptcha.Core;
using static Lazy.SlideCaptcha.Core.ValidateResult;
using Volo.Abp;

namespace Paas.Pioneer.Admin.Core.Application.Auth
{
    public class AuthService : ApplicationService, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppConfig _appConfig;
        private readonly IPermissionRepository _permissionRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IViewRepository _viewRepository;
        private readonly RedisAdminKeys _redisAdminKeys;
        private readonly ICaptcha _captcha;

        public AuthService(IOptions<AppConfig> appConfig,
            IUserRepository userRepository,
            IPermissionRepository permissionRepository,
            ITenantRepository tenantRepository,
            ICaptcha captcha,
            IViewRepository viewRepository,
            RedisAdminKeys redisAdminKeys)
        {
            _appConfig = appConfig.Value;
            _userRepository = userRepository;
            _permissionRepository = permissionRepository;
            _tenantRepository = tenantRepository;
            _captcha = captcha;
            _viewRepository = viewRepository;
            _redisAdminKeys = redisAdminKeys;
        }

        public async Task<GetPassWordEncryptKeyOutput> GetPassWordEncryptKeyAsync()
        {
            //写入Redis
            var guid = Guid.NewGuid().ToString("N");
            var key = string.Format(_redisAdminKeys.PassWordEncryptKey, guid);
            var encyptKey = StringHelper.GenerateRandom(8);
            await RedisHelper.SetAsync(key, encyptKey, TimeSpan.FromMinutes(5));
            var data = new GetPassWordEncryptKeyOutput
            {
                Key = guid,
                EncyptKey = encyptKey
            };
            return data;
        }

        public async Task<AuthUserInfoOutput> GetUserInfoAsync()
        {
            var authUserInfoOutput = new AuthUserInfoOutput();

            //用户信息
            authUserInfoOutput.User = await _userRepository.GetAsync(expression: x => x.Id == CurrentUser.Id, selector: x => new AuthUserProfileDto
            {
                Avatar = x.Avatar,
                NickName = x.NickName,
                UserName = x.UserName
            });

            //用户菜单
            var viewList = await _viewRepository.GetListAsync();
            bool isTenant = false;
            if (_appConfig.Tenant && CurrentUser.FindClaim(ClaimAttributes.TenantType).Value == ((int)ETenantType.Tenant).ToString())
            {
                isTenant = true;
            }
            var menu = await _permissionRepository.GetPermissionsMenuAsync(CurrentUser.Id, isTenant);

            authUserInfoOutput.Menus = new List<AuthUserMenuDto>();

            foreach (var m in menu)
            {
                AuthUserMenuDto authUserMenuModel = new AuthUserMenuDto()
                {
                    Id = m.Id,
                    Closable = m.Closable,
                    External = m.External,
                    Hidden = m.Hidden,
                    Icon = m.Icon,
                    Label = m.Label,
                    NewWindow = m.NewWindow,
                    Opened = m.Opened,
                    ParentId = m.ParentId,
                    Path = m.Path,
                    ViewPath = viewList.Where(a => a.Id == m.ViewId).Select(a => a.Path).FirstOrDefault()
                };
                authUserInfoOutput.Menus.Add(authUserMenuModel);
            }

            ////用户权限点
            authUserInfoOutput.Permissions = await _permissionRepository.GetPermissionsCodeListAsync(CurrentUser.Id, isTenant);

            return authUserInfoOutput;
        }

        /// <summary>
        /// 用户权限点
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetPermissionsCodeListAsync(Guid? userId)
        {
            bool isTenant = false;
            if (_appConfig.Tenant && CurrentUser.FindClaim(ClaimAttributes.TenantType).Value == ((int)ETenantType.Tenant).ToString())
            {
                isTenant = true;
            }
            return await _permissionRepository.GetPermissionsCodeListAsync(userId, isTenant);
        }

        public async Task<AuthLoginOutput> LoginAsync(AuthLoginInput input)
        {
            #region 验证码校验
            if (_appConfig.VarifyCode.Enable)
            {
                var isSuccees = _captcha.Validate(input.Captcha.Id, input.Captcha.track);
                if (isSuccees.Result != ValidateResultType.Success)
                {
                    throw new BusinessException("安全验证不通过，请重新登录！");
                }
            }
            #endregion 验证码校验
            var user = await _userRepository.GetAsync(expression: x => x.UserName == input.UserName);
            if (user == null)
            {
                throw new BusinessException("账号输入有误!");
            }
            if (!user.Enabled)
            {
                throw new BusinessException("账号已被禁用");
            }
            #region 解密
            if (!input.PasswordKey.IsNullOrEmpty())
            {
                var passwordEncryptKey = string.Format(_redisAdminKeys.PassWordEncryptKey, input.PasswordKey);
                var existsPasswordKey = await RedisHelper.ExistsAsync(passwordEncryptKey);
                if (existsPasswordKey)
                {
                    var secretKey = await RedisHelper.GetAsync(passwordEncryptKey);
                    if (secretKey.IsNullOrEmpty())
                    {
                        throw new BusinessException("解密失败！");
                    }
                    input.Password = DesEncrypt.Decrypt(input.Password, secretKey);
                    await RedisHelper.DelAsync(passwordEncryptKey);
                }
                else
                {
                    throw new BusinessException("解密失败！");
                }
            }
            #endregion 解密

            var password = MD5Encrypt.Encrypt32(input.Password);
            if (user.Password != password)
            {
                throw new BusinessException("密码输入有误！");
            }

            var authLoginOutput = ObjectMapper.Map<Ad_UserEntity, AuthLoginOutput>(user);

            if (_appConfig.Tenant)
            {
                var tenant = await _tenantRepository.GetAsync(expression: x => x.Id == user.TenantId, isTracking: true);
                if (tenant == null)
                {
                    throw new BusinessException("平台信息为空");
                }
                if (!tenant.GetProperty<bool>("Enabled"))
                {
                    throw new BusinessException("平台已被禁用");
                }
                authLoginOutput.TenantType = tenant.GetProperty<ETenantType>("TenantType");
            }
            return authLoginOutput;
        }
    }
}