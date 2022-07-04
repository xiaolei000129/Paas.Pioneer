using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.WeChat.Domain.MiniPrograms.UserInfos;
using Paas.Pioneer.WeChat.Domain.MiniPrograms;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.MiniPrograms.EntityFrameworkCore
{
    [ConnectionStringName(MiniProgramsDbProperties.ConnectionStringName)]
    public interface IMiniProgramsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<UserInfo> UserInfos { get; set; }
    }
}
