using System.Threading.Tasks;
using Paas.Pioneer.User.Application.Contracts.Identity.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.User.Application.Contracts.Identity
{
    public interface IProfileAppService : IApplicationService
    {
        Task BindPhoneNumberAsync(BindPhoneNumberInput input);
    }
}