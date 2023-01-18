using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainPostsAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    post_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post_description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    is_a_project = table.Column<bool>(type: "bit", nullable: false),
                    post_active = table.Column<bool>(type: "bit", nullable: false),
                    post_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PostItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    post_type = table.Column<int>(type: "int", nullable: false),
                    subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostItems_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostItems_PostId",
                table: "PostItems",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostItems");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
