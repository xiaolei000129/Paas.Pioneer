using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.Message.Domain.MessageData;
using Paas.Pioneer.Message.Domain.MessageDetails;
using Paas.Pioneer.Message.Domain.Notification;
using Paas.Pioneer.Message.Domain.UserReadNotificationDetails;
using System;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Paas.Pioneer.Message.EntityFrameworkCore.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class MessagesDbContext :
        AbpDbContext<MessagesDbContext>,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
        public DbSet<Mes_Data> Mes_Datas { get; set; }
        public DbSet<Mes_Details> Mes_Detailss { get; set; }
        public DbSet<Mes_Notification> Mes_Notifications { get; set; }
        public DbSet<Mes_UserReadNotificationDetails> Mes_UserReadNotificationDetailss { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .ConfigureWarnings(b => b.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();


        public MessagesDbContext(DbContextOptions<MessagesDbContext> options)
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
            //    b.ToTable(MessagesConsts.DbTablePrefix + "YourEntities", MessagesConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
