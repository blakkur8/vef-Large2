using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleground.Api.Migrations
{
    public partial class Fix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattlesPlayers");

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Battles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BattlePlayer",
                columns: table => new
                {
                    BattleId = table.Column<int>(type: "integer", nullable: false),
                    PlayerInMatchId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattlePlayer", x => new { x.PlayerInMatchId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_BattlePlayer_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattlePlayer_Players_PlayerInMatchId",
                        column: x => x.PlayerInMatchId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_WinnerId",
                table: "Battles",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BattlePlayer_BattleId",
                table: "BattlePlayer",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles");

            migrationBuilder.DropTable(
                name: "BattlePlayer");

            migrationBuilder.DropIndex(
                name: "IX_Battles_WinnerId",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Battles");

            migrationBuilder.CreateTable(
                name: "BattlesPlayers",
                columns: table => new
                {
                    BattlesId = table.Column<int>(type: "integer", nullable: false),
                    PlayersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattlesPlayers", x => new { x.BattlesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_BattlesPlayers_Battles_BattlesId",
                        column: x => x.BattlesId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattlesPlayers_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattlesPlayers_PlayersId",
                table: "BattlesPlayers",
                column: "PlayersId");
        }
    }
}
