using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Migrations
{
    public partial class add_table_Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IDX_ParentId3",
                table: "Pe_Organization",
                newName: "IDX_ParentId4");

            migrationBuilder.RenameIndex(
                name: "IDX_ParentId4",
                table: "Ad_View",
                newName: "IDX_ParentId5");

            migrationBuilder.RenameIndex(
                name: "IDX_ParentId2",
                table: "Ad_Permission",
                newName: "IDX_ParentId3");

            migrationBuilder.RenameIndex(
                name: "IDX_ParentId1",
                table: "Ad_Document",
                newName: "IDX_ParentId2");

            migrationBuilder.CreateTable(
                name: "Information_Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BusinessId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "业务Id", collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "父级Id", collation: "ascii_general_ci"),
                    Details = table.Column<string>(type: "varchar(500)", nullable: true, comment: "评论详情")
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
                    table.PrimaryKey("PK_Information_Comment", x => x.Id);
                },
                comment: "评论表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IDX_BusinessId",
                table: "Information_Comment",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IDX_ParentId1",
                table: "Information_Comment",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Information_Comment");

            migrationBuilder.RenameIndex(
                name: "IDX_ParentId4",
                table: "Pe_Organization",
                newName: "IDX_ParentId3");

            migrationBuilder.RenameIndex(
                name: "IDX_ParentId5",
                table: "Ad_View",
                newName: "IDX_ParentId4");

            migrationBuilder.RenameIndex(
                name: "IDX_ParentId3",
                table: "Ad_Permission",
                newName: "IDX_ParentId2");

            migrationBuilder.RenameIndex(
                name: "IDX_ParentId2",
                table: "Ad_Document",
                newName: "IDX_ParentId1");
        }
    }
}
