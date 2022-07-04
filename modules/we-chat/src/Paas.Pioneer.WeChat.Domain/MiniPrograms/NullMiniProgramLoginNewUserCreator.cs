using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Paas.Pioneer.WeChat.Domain.MiniPrograms
{
    public class NullMiniProgramLoginNewUserCreator : IMiniProgramLoginNewUserCreator
    {
        public virtual Task<IdentityUser> CreateAsync(string loginProvider, string providerKey)
        {
            throw new MiniProgramLoginMatchNoUserException();
        }
    }
}