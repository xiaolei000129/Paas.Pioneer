using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Migrations
{
    public partial class init_news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Information_Grid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DictionaryId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "字典Id", collation: "ascii_general_ci"),
                    GridType = table.Column<int>(type: "int", nullable: false, comment: "栅格管理类型"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Portrait = table.Column<string>(type: "varchar(200)", nullable: true, comment: "图片")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expand = table.Column<string>(type: "varchar(200)", nullable: true, comment: "拓展信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true, comment: "描述")
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
                    table.PrimaryKey("PK_Information_Grid", x => x.Id);
                },
                comment: "栅格管理")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Information_News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DictionaryId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "字典Id", collation: "ascii_general_ci"),
                    Portrait = table.Column<string>(type: "varchar(200)", nullable: true, comment: "图片")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PushTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "发布时间"),
                    NewsContent = table.Column<string>(type: "text", nullable: true, comment: "新闻内容")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "隐藏"),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "启用"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true, comment: "描述")
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
                    table.PrimaryKey("PK_Information_News", x => x.Id);
                },
                comment: "新闻表管理")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Information_Slideshow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DictionaryId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "字典Id", collation: "ascii_general_ci"),
                    SlideshowType = table.Column<int>(type: "int", nullable: false, comment: "轮播图类型"),
                    Expand = table.Column<string>(type: "varchar(200)", nullable: true, comment: "拓展信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(100)", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Portrait = table.Column<string>(type: "varchar(200)", nullable: true, comment: "图片")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true, comment: "描述")
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
                    table.PrimaryKey("PK_Information_Slideshow", x => x.Id);
                },
                comment: "轮播图管理")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Information_Grid");

            migrationBuilder.DropTable(
                name: "Information_News");

            migrationBuilder.DropTable(
                name: "Information_Slideshow");
        }
    }
}
