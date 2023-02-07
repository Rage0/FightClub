using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations.IdentityApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateClubEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Club_ClubId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AspNetUsers_CreaterId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_CreaterId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_CreaterId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Massage_AspNetUsers_CreaterId",
                table: "Massage");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_CreaterId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Club_CreaterId",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Post",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CreaterId",
                table: "Post",
                newName: "IX_Post_ProfileId");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Massage",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Massage_CreaterId",
                table: "Massage",
                newName: "IX_Massage_ProfileId");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Chat",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_CreaterId",
                table: "Chat",
                newName: "IX_Chat_ProfileId");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Bet",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_CreaterId",
                table: "Bet",
                newName: "IX_Bet_ProfileId");

            migrationBuilder.RenameColumn(
                name: "ClubId1",
                table: "AspNetUsers",
                newName: "ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ClubId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Club_ClubId",
                table: "AspNetUsers",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_ProfileId",
                table: "Bet",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_ProfileId",
                table: "Chat",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massage_AspNetUsers_ProfileId",
                table: "Massage",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ProfileId",
                table: "Post",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Club_ClubId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AspNetUsers_ProfileId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_ProfileId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Massage_AspNetUsers_ProfileId",
                table: "Massage");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_ProfileId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Post",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_ProfileId",
                table: "Post",
                newName: "IX_Post_CreaterId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Massage",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Massage_ProfileId",
                table: "Massage",
                newName: "IX_Massage_CreaterId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Chat",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_ProfileId",
                table: "Chat",
                newName: "IX_Chat_CreaterId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Bet",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_ProfileId",
                table: "Bet",
                newName: "IX_Bet_CreaterId");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "AspNetUsers",
                newName: "ClubId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ClubId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ClubId1");

            migrationBuilder.CreateIndex(
                name: "IX_Club_CreaterId",
                table: "Club",
                column: "CreaterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Club_ClubId1",
                table: "AspNetUsers",
                column: "ClubId1",
                principalTable: "Club",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_CreaterId",
                table: "Bet",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_CreaterId",
                table: "Chat",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_CreaterId",
                table: "Club",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massage_AspNetUsers_CreaterId",
                table: "Massage",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_CreaterId",
                table: "Post",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
