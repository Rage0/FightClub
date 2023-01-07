using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddUserObjectForEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_User_UserId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_User_UserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_User_UserId",
                table: "Massages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_User_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Massages_UserId",
                table: "Massages");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Massages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bets");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Massages_AuthorId",
                table: "Massages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AuthorId",
                table: "Chats",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_AuthorId",
                table: "Bets",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_User_AuthorId",
                table: "Bets",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_User_AuthorId",
                table: "Chats",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_User_AuthorId",
                table: "Massages",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_User_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_User_AuthorId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_User_AuthorId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_User_AuthorId",
                table: "Massages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_User_AuthorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Massages_AuthorId",
                table: "Massages");

            migrationBuilder.DropIndex(
                name: "IX_Chats_AuthorId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Bets_AuthorId",
                table: "Bets");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Massages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Chats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bets",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Massages_UserId",
                table: "Massages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_User_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_User_UserId",
                table: "Chats",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_User_UserId",
                table: "Massages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_User_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
