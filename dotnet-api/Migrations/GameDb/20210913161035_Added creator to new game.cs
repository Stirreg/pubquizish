using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations.GameDb
{
    public partial class Addedcreatortonewgame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Creator",
                table: "NewGames",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "NewGames");
        }
    }
}
