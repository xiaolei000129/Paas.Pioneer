using Volo.Abp;

namespace Paas.Pioneer.WeChat.Domain.MiniPrograms
{
    public class MiniProgramLoginMatchNoUserException : BusinessException
    {
        public MiniProgramLoginMatchNoUserException() : base("MiniProgramLoginMatchNoUser", "请先创建账号")
        {

        }
    }
}