using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinksProject.Migrations
{
    public partial class addTelegramPasswordInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelegramPassword",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramPassword",
                table: "Users");
        }
    }
}
