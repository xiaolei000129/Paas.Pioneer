using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.Admin.Core.Domain.Api;
using Paas.Pioneer.Admin.Core.Domain.Comment;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Paas.Pioneer.Admin.Core.Domain.DictionaryType;
using Paas.Pioneer.Admin.Core.Domain.Document;
using Paas.Pioneer.Admin.Core.Domain.DocumentImage;
using Paas.Pioneer.Admin.Core.Domain.LoginLog;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTable;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.PermissionApi;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Employee;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Organization;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Admin.Core.Domain.TenantPermission;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Admin.Core.Domain.View;
using System;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class AdminsDbContext :
        AbpDbContext<AdminsDbContext>,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        public DbSet<Ad_ApiEntity> Ad_ApiEntitys { get; set; }
        public DbSet<Ad_DictionaryEntity> Ad_DictionaryEntitys { get; set; }
        public DbSet<Ad_DictionaryTypeEntity> Ad_DictionaryTypeEntitys { get; set; }
        public DbSet<Ad_DocumentEntity> Ad_DocumentEntitys { get; set; }
        public DbSet<Ad_DocumentImageEntity> Ad_DocumentImageEntitys { get; set; }
        public DbSet<Ad_LoginLogEntity> Ad_LoginLogEntitys { get; set; }
        public DbSet<Ad_PermissionEntity> Ad_PermissionEntitys { get; set; }
        public DbSet<Ad_PermissionApiEntity> Ad_PermissionApiEntitys { get; set; }
        public DbSet<Ad_RoleEntity> Ad_RoleEntitys { get; set; }
        public DbSet<Ad_RolePermissionEntity> Ad_RolePermissionEntitys { get; set; }
        public DbSet<Ad_TenantPermissionEntity> Ad_TenantPermissionEntitys { get; set; }
        public DbSet<Ad_UserEntity> Ad_UserEntitys { get; set; }
        public DbSet<Ad_UserRoleEntity> Ad_UserRoleEntitys { get; set; }
        public DbSet<Ad_ViewEntity> Ad_ViewEntitys { get; set; }
        public DbSet<Pe_EmployeeEntity> Pe_EmployeeEntitys { get; set; }
        public DbSet<Pe_OrganizationEntity> Pe_OrganizationEntitys { get; set; }
        public DbSet<Pe_PositionEntity> Pe_PositionEntitys { get; set; }
        public DbSet<Ad_LowCodeTableConfigEntity> Ad_LowCodeTableConfigEntitys { get; set; }
        public DbSet<Ad_LowCodeTableEntity> Ad_LowCodeTableEntitys { get; set; }
        public DbSet<Information_CommentEntity> Information_CommentEntitys { get; set; }

        // Tenant Management
        public DbSet<Volo.Abp.TenantManagement.Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        public AdminsDbContext(DbContextOptions<AdminsDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .ConfigureWarnings(b => b.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
            .LogTo(Console.WriteLine, LogLevel.Information, DbContextLoggerOptions.Level)
           .EnableDetailedErrors();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AdminsConsts.DbTablePrefix + "YourEntities", AdminsConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
