using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.User.Application.Contracts.Login.Dtos
{
    [Serializable]
    public class PcLoginInput
    {
        [Required]
        public string Token { get; set; }
    }
}