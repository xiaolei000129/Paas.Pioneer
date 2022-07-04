using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Identity.Dtos
{
    public class BindPhoneNumberInput
    {
        [Required]
        public string AppId { get; set; }

        [Required]
        public string Code { get; set; }
    }
}