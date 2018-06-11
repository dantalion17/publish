using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinksProject.Migrations
{
    public partial class ChangeTgChatIdIntToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TgChatId",
                table: "ActiveLists",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TgChatId",
                table: "ActiveLists",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
