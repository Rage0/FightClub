using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeleteDependentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Clubs_ClubId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Clubs_ClubId",
                table: "Chats",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Clubs_ClubId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Clubs_ClubId",
                table: "Chats",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "UserId");
        }
    }
}
