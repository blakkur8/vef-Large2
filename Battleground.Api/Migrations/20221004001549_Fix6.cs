using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleground.Api.Migrations
{
    public partial class Fix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attacks_BattlePokemons_BattleId1_BattlePokemonIdentifier",
                table: "Attacks");

            migrationBuilder.DropIndex(
                name: "IX_Attacks_BattleId1_BattlePokemonIdentifier",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "BattleId1",
                table: "Attacks");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_BattleId_BattlePokemonIdentifier",
                table: "Attacks",
                columns: new[] { "BattleId", "BattlePokemonIdentifier" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attacks_BattlePokemons_BattleId_BattlePokemonIdentifier",
                table: "Attacks",
                columns: new[] { "BattleId", "BattlePokemonIdentifier" },
                principalTable: "BattlePokemons",
                principalColumns: new[] { "BattleId", "PokemonIdentifier" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attacks_BattlePokemons_BattleId_BattlePokemonIdentifier",
                table: "Attacks");

            migrationBuilder.DropIndex(
                name: "IX_Attacks_BattleId_BattlePokemonIdentifier",
                table: "Attacks");

            migrationBuilder.AddColumn<int>(
                name: "BattleId1",
                table: "Attacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_BattleId1_BattlePokemonIdentifier",
                table: "Attacks",
                columns: new[] { "BattleId1", "BattlePokemonIdentifier" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attacks_BattlePokemons_BattleId1_BattlePokemonIdentifier",
                table: "Attacks",
                columns: new[] { "BattleId1", "BattlePokemonIdentifier" },
                principalTable: "BattlePokemons",
                principalColumns: new[] { "BattleId", "PokemonIdentifier" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
