namespace Paas.Pioneer.WeChat.Domain.MiniPrograms
{
    public static class MiniProgramsDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpWeChatManagementMiniPrograms";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpWeChatManagementMiniPrograms";
    }
}
