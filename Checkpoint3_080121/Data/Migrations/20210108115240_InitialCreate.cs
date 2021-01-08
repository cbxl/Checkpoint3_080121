using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkpoint3_080121.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pseudo",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Pseudo",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
