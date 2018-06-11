using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinksProject.Migrations
{
    public partial class changetypedatetimelastchangeisendwriteinActiveList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeLastChangeIsEndWrite",
                table: "ActiveLists");

            migrationBuilder.AddColumn<int>(
                name: "DateTimeLastChangeIsEndWriteHours",
                table: "ActiveLists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeLastChangeIsEndWriteHours",
                table: "ActiveLists");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeLastChangeIsEndWrite",
                table: "ActiveLists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
