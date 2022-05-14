using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.Information.Domain.Comment;
using Paas.Pioneer.Information.Domain.Grid;
using Paas.Pioneer.Information.Domain.News;
using Paas.Pioneer.Information.Domain.Slideshow;
using System;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Paas.Pioneer.Information.EntityFrameworkCore.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class InformationsDbContext :
        AbpDbContext<InformationsDbContext>,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        #region 资讯管理
        public DbSet<Information_CommentEntity> Information_CommentEntitys { get; set; }
        public DbSet<Information_GridEntity> Information_GridEntitys { get; set; }
        public DbSet<Information_NewsEntity> Information_NewsEntitys { get; set; }
        public DbSet<Information_SlideshowEntity> Information_SlideshowEntitys { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .ConfigureWarnings(b => b.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();


        public InformationsDbContext(DbContextOptions<InformationsDbContext> options)
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
            //    b.ToTable(InformationsConsts.DbTablePrefix + "YourEntities", InformationsConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
