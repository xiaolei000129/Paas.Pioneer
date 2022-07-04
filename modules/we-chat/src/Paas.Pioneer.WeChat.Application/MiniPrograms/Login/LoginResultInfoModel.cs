using EasyAbp.Abp.WeChat.MiniProgram.Services.Login;
using Paas.Pioneer.WeChat.Domain.WeChatApps;

namespace Paas.Pioneer.WeChat.Application.MiniPrograms.Login
{
    public record LoginResultInfoModel
    {
        public WeChatApp MiniProgram { get; init; }

        public string LoginProvider { get; init; }

        public string ProviderKey { get; init; }

        public string UnionId { get; init; }

        public Code2SessionResponse Code2SessionResponse { get; init; }
    }
}