using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.User.Application.Contracts.Identity.Dtos
{
    public class BindPhoneNumberInput
    {
        [Required]
        public string AppId { get; set; }

        [Required]
        public string Code { get; set; }
    }
}