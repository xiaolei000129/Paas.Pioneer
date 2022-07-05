using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Paas.Pioneer.User.Application.Contracts.Identity;
using Paas.Pioneer.User.Application.Contracts.Identity.Dtos;
using Volo.Abp;
using Volo.Abp.Users;

namespace Paas.Pioneer.User.Application.Identity
{
    [Authorize]
    public class ProfileAppService : MiniProgramsAppService, IProfileAppService
    {
        private readonly PhoneNumberService _phoneNumberService;
        private readonly IOptions<IdentityOptions> _identityOptions;
        private readonly IdentityUserManager _identityUserManager;
        private readonly IWeChatAppRepository _weChatAppRepository;
        private readonly IWeChatMiniProgramAsyncLocal _weChatMiniProgramAsyncLocal;

        public ProfileAppService(
            IOptions<IdentityOptions> identityOptions,
            IdentityUserManager identityUserManager,
            IWeChatAppRepository weChatAppRepository,
            PhoneNumberService phoneNumberService,
            IWeChatMiniProgramAsyncLocal weChatMiniProgramAsyncLocal)
        {
            ;
            _identityOptions = identityOptions;
            _identityUserManager = identityUserManager;
            _weChatAppRepository = weChatAppRepository;
            _phoneNumberService = phoneNumberService;
            _weChatMiniProgramAsyncLocal = weChatMiniProgramAsyncLocal;
        }

        /// <summary>
        /// 通过微信开放能力获取并给当前用户绑定手机号，更新信息：https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/getPhoneNumber.html
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        /// <exception cref="AbpIdentityResultException"></exception>
        public async Task BindPhoneNumberAsync(BindPhoneNumberInput input)
        {
            await _identityOptions.SetAsync();

            var user = await _identityUserManager.GetByIdAsync(CurrentUser.GetId());

            var miniProgram = await _weChatAppRepository.GetMiniProgramAppByAppIdAsync(input.AppId);

            var options = new AbpWeChatMiniProgramOptions
            {
                OpenAppId = miniProgram.OpenAppIdOrName,
                AppId = miniProgram.AppId,
                AppSecret = miniProgram.AppSecret,
                EncodingAesKey = miniProgram.EncodingAesKey,
                Token = miniProgram.Token
            };

            using (_weChatMiniProgramAsyncLocal.Change(options))
            {
                var response = await _phoneNumberService.GetPhoneNumberAsync(input.Code);

                if (response.ErrorCode != 0)
                {
                    throw new BusinessException(message: $"WeChat error: [{response.ErrorCode}]: {response.ErrorMessage}");
                }

                var phoneNumber = response.PhoneInfo.PhoneNumber;

                _identityUserManager.RegisterTokenProvider(TokenOptions.DefaultPhoneProvider,
                    new StaticPhoneNumberTokenProvider());

                var token = await _identityUserManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);

                var identityResult = await _identityUserManager.ChangePhoneNumberAsync(user, phoneNumber, token);

                if (!identityResult.Succeeded)
                {
                    throw new AbpIdentityResultException(identityResult);
                }
            }
        }
    }
}