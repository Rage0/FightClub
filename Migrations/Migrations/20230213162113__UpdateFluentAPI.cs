using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserProfile_ProfileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages");

            migrationBuilder.AlterColumn<string>(
                name: "CreaterId",
                table: "Clubs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "Chats",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserProfile_ProfileId",
                table: "Chats",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserProfile_ProfileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages");

            migrationBuilder.AlterColumn<string>(
                name: "CreaterId",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "Chats",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Fights_FightId",
                table: "Bets",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Posts_PostId",
                table: "Chats",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserProfile_ProfileId",
                table: "Chats",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_Chats_ChatId",
                table: "Massages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
