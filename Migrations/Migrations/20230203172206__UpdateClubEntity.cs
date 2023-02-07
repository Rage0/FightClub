using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClubEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_UserProfile_CreaterId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserProfile_CreaterId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_UserProfile_CreaterId",
                table: "Massages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserProfile_CreaterId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Posts",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CreaterId",
                table: "Posts",
                newName: "IX_Posts_ProfileId");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Massages",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Massages_CreaterId",
                table: "Massages",
                newName: "IX_Massages_ProfileId");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Chats",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_CreaterId",
                table: "Chats",
                newName: "IX_Chats_ProfileId");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Bets",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_CreaterId",
                table: "Bets",
                newName: "IX_Bets_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_UserProfile_ProfileId",
                table: "Bets",
                column: "ProfileId",
                principalTable: "UserProfile",
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
                name: "FK_Massages_UserProfile_ProfileId",
                table: "Massages",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserProfile_ProfileId",
                table: "Posts",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_UserProfile_ProfileId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserProfile_ProfileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_UserProfile_ProfileId",
                table: "Massages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserProfile_ProfileId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Posts",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts",
                newName: "IX_Posts_CreaterId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Massages",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Massages_ProfileId",
                table: "Massages",
                newName: "IX_Massages_CreaterId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Chats",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_ProfileId",
                table: "Chats",
                newName: "IX_Chats_CreaterId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Bets",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_ProfileId",
                table: "Bets",
                newName: "IX_Bets_CreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_UserProfile_CreaterId",
                table: "Bets",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserProfile_CreaterId",
                table: "Chats",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_UserProfile_CreaterId",
                table: "Massages",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserProfile_CreaterId",
                table: "Posts",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
