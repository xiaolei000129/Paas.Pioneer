using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RealName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true, collation: "ascii_general_ci"),
                    TenantType = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true, collation: "ascii_general_ci"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Api",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "所属模块", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "接口命名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Label = table.Column<string>(type: "varchar(500)", nullable: true, comment: "接口名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "varchar(500)", nullable: true, comment: "接口地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HttpMethods = table.Column<string>(type: "varchar(50)", nullable: true, comment: "接口提交方法")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "说明")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Api", x => x.Id);
                },
                comment: "接口管理")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Dictionary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DictionaryTypeId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "字典类型Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "文章标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true, comment: "字典编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(50)", nullable: true, comment: "字典值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Dictionary", x => x.Id);
                },
                comment: "数据字典")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Dictionary_Type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "文章标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Dictionary_Type", x => x.Id);
                },
                comment: "数据字典类型")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级节点", collation: "ascii_general_ci"),
                    Label = table.Column<string>(type: "varchar(50)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "类型"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "命名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true, comment: "内容")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Html = table.Column<string>(type: "longtext", nullable: true, comment: "Html")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Opened = table.Column<bool>(type: "tinyint(1)", nullable: true, comment: "打开组"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Document", x => x.Id);
                },
                comment: "文档表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Document_Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocumentId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "文档Id", collation: "ascii_general_ci"),
                    Url = table.Column<string>(type: "longtext", nullable: true, comment: "文档Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Document_Image", x => x.Id);
                },
                comment: "文档图片表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Login_Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NickName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "昵称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IP = table.Column<string>(type: "varchar(100)", nullable: true, comment: "IP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Browser = table.Column<string>(type: "varchar(100)", nullable: true, comment: "浏览器")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Os = table.Column<string>(type: "varchar(100)", nullable: true, comment: "操作系统")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Device = table.Column<string>(type: "varchar(50)", nullable: true, comment: "设备")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrowserInfo = table.Column<string>(type: "longtext", nullable: true, comment: "浏览器信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ElapsedMilliseconds = table.Column<long>(type: "bigint", nullable: false, comment: "耗时（毫秒）"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "操作状态"),
                    Msg = table.Column<string>(type: "varchar(500)", nullable: true, comment: "操作消息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Result = table.Column<string>(type: "longtext", nullable: true, comment: "操作结果")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Login_Log", x => x.Id);
                },
                comment: "登录日志表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_LowCodeTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "所属节点（菜单父级Id）", collation: "ascii_general_ci"),
                    MenuName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "菜单名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LowCodeTableName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "表名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Taxon = table.Column<string>(type: "varchar(50)", nullable: true, comment: "代码类名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FunctionModule = table.Column<string>(type: "varchar(100)", nullable: true, comment: "所属功能模块（业务场景）")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_LowCodeTable", x => x.Id);
                },
                comment: "低代码表格")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_LowCodeTableConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LowCodeTableId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "LowCodeTableId,父Id", collation: "ascii_general_ci"),
                    ColumnName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "字段名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNullable = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否为可空类型"),
                    IsWebAdd = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否需要前端添加"),
                    IsWebUpdate = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否需要前端修改"),
                    IsWebSelect = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否需要前端查询"),
                    IsWebShow = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否需要前端显示"),
                    QueryType = table.Column<int>(type: "int", nullable: false, comment: "查询方式"),
                    InputType = table.Column<int>(type: "int", nullable: false, comment: "输入类型"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_LowCodeTableConfig", x => x.Id);
                },
                comment: "低代码表格配置")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "父级节点", collation: "ascii_general_ci"),
                    Label = table.Column<string>(type: "varchar(50)", nullable: true, comment: "权限名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true, comment: "权限编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "权限类型"),
                    ViewId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "视图", collation: "ascii_general_ci"),
                    Path = table.Column<string>(type: "varchar(50)", nullable: true, comment: "菜单访问地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icon = table.Column<string>(type: "varchar(50)", nullable: true, comment: "图标")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hidden = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "隐藏"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Closable = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "可关闭"),
                    Opened = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "打开组"),
                    NewWindow = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "打开新窗口"),
                    External = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "链接外显"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Permission", x => x.Id);
                },
                comment: "权限表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Permission_Api",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PermissionId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "权限Id", collation: "ascii_general_ci"),
                    ApiId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "接口Id", collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Permission_Api", x => x.Id);
                },
                comment: "权限接口表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true, comment: "说明")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Role", x => x.Id);
                },
                comment: "角色表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Role_Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id", collation: "ascii_general_ci"),
                    PermissionId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "权限Id", collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Role_Permission", x => x.Id);
                },
                comment: "角色权限表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_Tenant_Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PermissionId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "权限Id", collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_Tenant_Permission", x => x.Id);
                },
                comment: "租户权限表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "账号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(60)", nullable: true, comment: "密码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NickName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "昵称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "varchar(500)", nullable: true, comment: "头像")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Remark = table.Column<string>(type: "varchar(500)", nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_User", x => x.Id);
                },
                comment: "用户表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_User_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id", collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_User_Role", x => x.Id);
                },
                comment: "用户角色表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ad_View",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "所属节点", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "视图命名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Label = table.Column<string>(type: "varchar(50)", nullable: true, comment: "视图名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "varchar(250)", nullable: true, comment: "视图路径")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "说明")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Cache = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "缓存"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad_View", x => x.Id);
                },
                comment: "视图管理表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pe_Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NickName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "昵称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sex = table.Column<int>(type: "int", nullable: false, comment: "性别"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true, comment: "工号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "主属部门Id", collation: "ascii_general_ci"),
                    PrimaryEmployeeId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "主管Id", collation: "ascii_general_ci"),
                    PositionId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "职位Id", collation: "ascii_general_ci"),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: true, comment: "手机号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntryTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "入职时间"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pe_Employee", x => x.Id);
                },
                comment: "员工表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pe_Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "父级", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(50)", nullable: true, comment: "值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrimaryEmployeeId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "主管Id", collation: "ascii_general_ci"),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false, comment: "员工人数"),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pe_Organization", x => x.Id);
                },
                comment: "组织架构表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pe_Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true, comment: "说明")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pe_Position", x => x.Id);
                },
                comment: "职位表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenantConnectionStrings",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantConnectionStrings", x => new { x.TenantId, x.Name });
                    table.ForeignKey(
                        name: "FK_AbpTenantConnectionStrings_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_Name",
                table: "AbpTenants",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IDX_ParentId",
                table: "Ad_Api",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IDX_Code",
                table: "Ad_Dictionary",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IDX_DictionaryTypeId",
                table: "Ad_Dictionary",
                column: "DictionaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IDX_Code1",
                table: "Ad_Dictionary_Type",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IDX_ParentId1",
                table: "Ad_Document",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IDX_DocumentId",
                table: "Ad_Document_Image",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IDX_LowCodeTableId",
                table: "Ad_LowCodeTableConfig",
                column: "LowCodeTableId");

            migrationBuilder.CreateIndex(
                name: "IDX_ParentId2",
                table: "Ad_Permission",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IDX_ApiId",
                table: "Ad_Permission_Api",
                column: "ApiId");

            migrationBuilder.CreateIndex(
                name: "IDX_PermissionId",
                table: "Ad_Permission_Api",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IDX_PermissionId1",
                table: "Ad_Role_Permission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IDX_RoleId",
                table: "Ad_Role_Permission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IDX_PermissionId2",
                table: "Ad_Tenant_Permission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IDX_RoleId1",
                table: "Ad_User_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IDX_UserId1",
                table: "Ad_User_Role",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IDX_ParentId4",
                table: "Ad_View",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IDX_OrganizationId",
                table: "Pe_Employee",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IDX_PositionId",
                table: "Pe_Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IDX_PrimaryEmployeeId",
                table: "Pe_Employee",
                column: "PrimaryEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IDX_UserId",
                table: "Pe_Employee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IDX_ParentId3",
                table: "Pe_Organization",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IDX_PrimaryEmployeeId1",
                table: "Pe_Organization",
                column: "PrimaryEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpTenantConnectionStrings");

            migrationBuilder.DropTable(
                name: "Ad_Api");

            migrationBuilder.DropTable(
                name: "Ad_Dictionary");

            migrationBuilder.DropTable(
                name: "Ad_Dictionary_Type");

            migrationBuilder.DropTable(
                name: "Ad_Document");

            migrationBuilder.DropTable(
                name: "Ad_Document_Image");

            migrationBuilder.DropTable(
                name: "Ad_Login_Log");

            migrationBuilder.DropTable(
                name: "Ad_LowCodeTable");

            migrationBuilder.DropTable(
                name: "Ad_LowCodeTableConfig");

            migrationBuilder.DropTable(
                name: "Ad_Permission");

            migrationBuilder.DropTable(
                name: "Ad_Permission_Api");

            migrationBuilder.DropTable(
                name: "Ad_Role");

            migrationBuilder.DropTable(
                name: "Ad_Role_Permission");

            migrationBuilder.DropTable(
                name: "Ad_Tenant_Permission");

            migrationBuilder.DropTable(
                name: "Ad_User");

            migrationBuilder.DropTable(
                name: "Ad_User_Role");

            migrationBuilder.DropTable(
                name: "Ad_View");

            migrationBuilder.DropTable(
                name: "Pe_Employee");

            migrationBuilder.DropTable(
                name: "Pe_Organization");

            migrationBuilder.DropTable(
                name: "Pe_Position");

            migrationBuilder.DropTable(
                name: "AbpTenants");
        }
    }
}
