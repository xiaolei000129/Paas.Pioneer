using System.Threading.Tasks;
using Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Identity.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Identity
{
    public interface IProfileAppService : IApplicationService
    {
        Task BindPhoneNumberAsync(BindPhoneNumberInput input);
    }
}