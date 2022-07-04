using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.WeChat.Domain.MiniPrograms.UserInfos;
using Paas.Pioneer.WeChat.Domain.MiniPrograms;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.MiniPrograms.EntityFrameworkCore
{
    [ConnectionStringName(MiniProgramsDbProperties.ConnectionStringName)]
    public class MiniProgramsDbContext : AbpDbContext<MiniProgramsDbContext>, IMiniProgramsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DbSet<UserInfo> UserInfos { get; set; }

        public MiniProgramsDbContext(DbContextOptions<MiniProgramsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureWeChatManagementMiniPrograms();
        }
    }
}
