using System;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Login.Dtos
{
    [Serializable]
    public class GetPcLoginACodeOutput
    {
        public string HandlePage { get; set; }

        public string Token { get; set; }

        public byte[] ACode { get; set; }
    }
}