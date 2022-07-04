using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.WeChat.Domain.WeChatApps;
using Paas.Pioneer.WeChat.Domain.WeChatAppUsers;
using System;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class WeChatsDbContext :
        AbpDbContext<WeChatsDbContext>,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        // Tenant Management
        public DbSet<WeChatApp> WeChatApps { get; set; }
        public DbSet<WeChatAppUser> WeChatAppUsers { get; set; }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .ConfigureWarnings(b => b.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();


        public WeChatsDbContext(DbContextOptions<WeChatsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(WeChatsConsts.DbTablePrefix + "YourEntities", WeChatsConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
