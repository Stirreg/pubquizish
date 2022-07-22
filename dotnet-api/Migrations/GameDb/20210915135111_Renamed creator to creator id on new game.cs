using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations.GameDb
{
    public partial class Renamedcreatortocreatoridonnewgame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "NewGames",
                newName: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "NewGames",
                newName: "Creator");
        }
    }
}
