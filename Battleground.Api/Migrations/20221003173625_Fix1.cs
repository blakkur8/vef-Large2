using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleground.Api.Migrations
{
    public partial class Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Attacks_AttacksId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_AttacksId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AttacksId",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttacksId",
                table: "Players",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_AttacksId",
                table: "Players",
                column: "AttacksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Attacks_AttacksId",
                table: "Players",
                column: "AttacksId",
                principalTable: "Attacks",
                principalColumn: "Id");
        }
    }
}
