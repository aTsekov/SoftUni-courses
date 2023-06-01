using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("00c7933e-49f2-413e-add8-acdcfb77ec4e"), "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", "My Second Post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("117529d9-f60f-46e6-950c-2bd28e4c45da"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse aliquam, ante id sagittis interdum, mi diam lobortis nibh, ac varius magna ex a erat. Praesent pharetra justo vel ante blandit, ac tempus leo lacinia. Pellentesque iaculis quis arcu ut rutrum. Mauris sagittis maximus neque. Sed scelerisque turpis non magna dapibus", "My third Post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("8f0b33f9-8b00-4021-95c1-cac7332b8462"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras placerat vitae quam sed egestas. Pellentesque lobortis felis quam, quis rhoncus.", "My First Post" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
