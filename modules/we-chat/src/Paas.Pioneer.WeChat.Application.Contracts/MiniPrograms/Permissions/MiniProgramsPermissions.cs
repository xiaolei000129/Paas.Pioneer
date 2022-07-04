using Volo.Abp.Reflection;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Permissions
{
    public class MiniProgramsPermissions
    {
        public const string GroupName = "EasyAbp.WeChatManagement.MiniPrograms";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MiniProgramsPermissions));
        }

        public class UserInfo
        {
            public const string Default = GroupName + ".UserInfo";
        }
    }
}
