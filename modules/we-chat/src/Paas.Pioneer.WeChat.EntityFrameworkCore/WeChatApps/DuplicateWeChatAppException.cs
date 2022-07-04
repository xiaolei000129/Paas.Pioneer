using Volo.Abp;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.WeChatApps
{
    public class DuplicateWeChatAppException : BusinessException
    {
        public DuplicateWeChatAppException() : base("DuplicateWeChatApp", "重复的微信应用")
        {

        }
    }
}