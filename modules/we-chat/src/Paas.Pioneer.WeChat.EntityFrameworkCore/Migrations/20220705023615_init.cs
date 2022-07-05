using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeChat_App",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WeChatComponentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "微信组件Id", collation: "ascii_general_ci"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "微信app类型"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OpenAppIdOrName = table.Column<string>(type: "varchar(50)", nullable: true, comment: "开放Id或者名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppId = table.Column<string>(type: "varchar(50)", nullable: true, comment: "微信AppId")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppSecret = table.Column<string>(type: "varchar(150)", nullable: true, comment: "App密钥")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Token = table.Column<string>(type: "varchar(500)", nullable: true, comment: "微信Token")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EncodingAesKey = table.Column<string>(type: "varchar(500)", nullable: true, comment: "微信密钥")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsStatic = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否静态"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeChat_App", x => x.Id);
                },
                comment: "数据字典")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeChat_AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WeChatAppId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "微信appId", collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    UnionId = table.Column<string>(type: "varchar(150)", nullable: true, comment: "UnionId")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OpenId = table.Column<string>(type: "varchar(150)", nullable: true, comment: "OpenId")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SessionKey = table.Column<string>(type: "varchar(500)", nullable: true, comment: "SessionKey")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SessionKeyChangedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "SessionKey修改时间"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人", collation: "ascii_general_ci"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "修改人", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeChat_AppUser", x => x.Id);
                },
                comment: "数据字典")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IDX_AppId",
                table: "WeChat_App",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IDX_Name",
                table: "WeChat_App",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IDX_UserId",
                table: "WeChat_AppUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IDX_WeChatAppId",
                table: "WeChat_AppUser",
                column: "WeChatAppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeChat_App");

            migrationBuilder.DropTable(
                name: "WeChat_AppUser");
        }
    }
}
