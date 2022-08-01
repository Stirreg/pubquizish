using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations.GameDb
{
    public partial class RenameNewGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewGames",
                table: "NewGames");

            migrationBuilder.RenameTable(
                name: "NewGames",
                newName: "NewGame");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewGame",
                table: "NewGame",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewGame",
                table: "NewGame");

            migrationBuilder.RenameTable(
                name: "NewGame",
                newName: "NewGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewGames",
                table: "NewGames",
                column: "Id");
        }
    }
}
