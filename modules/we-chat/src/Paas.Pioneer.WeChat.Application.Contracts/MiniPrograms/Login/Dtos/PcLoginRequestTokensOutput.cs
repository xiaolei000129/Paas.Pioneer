using System;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Login.Dtos
{
    [Serializable]
    public class PcLoginRequestTokensOutput : PcLoginOutput
    {
        public string RawData { get; set; }
    }
}