using System;

namespace Paas.Pioneer.User.Application.Contracts.Login.Dtos
{
    [Serializable]
    public class PcLoginRequestTokensOutput : PcLoginOutput
    {
        public string RawData { get; set; }
    }
}