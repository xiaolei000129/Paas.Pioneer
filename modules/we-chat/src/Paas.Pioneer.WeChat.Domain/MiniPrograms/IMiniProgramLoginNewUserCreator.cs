using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Paas.Pioneer.WeChat.Domain.MiniPrograms
{
    public interface IMiniProgramLoginNewUserCreator
    {
        Task<IdentityUser> CreateAsync(string loginProvider, string providerKey);
    }
}