using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations.IdentityApplicationDb
{
    /// <inheritdoc />
    public partial class ClubIdAddedToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Club_ClubId",
                table: "AspNetUsers",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_ProfileId",
                table: "Bet",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_ProfileId",
                table: "Chat",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Massage_AspNetUsers_ProfileId",
                table: "Massage",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ProfileId",
                table: "Post",
                column: "ProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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
    }
}
