using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_UserProfiles_ProfileId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserProfiles_ProfileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_UserProfiles_ProfileId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Massages_UserProfiles_ProfileId",
                table: "Massages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserProfiles_ProfileId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Clubs_ClubId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Fights_FightId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_IdentityUser_UserId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_ProfileId",
                table: "Clubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProfile",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_FightId",
                table: "UserProfile",
                newName: "IX_UserProfile_FightId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_ClubId",
                table: "UserProfile",
                newName: "IX_UserProfile_ClubId");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "UserProfile",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "UserProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "UserProfile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "UserProfile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "UserProfile",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "UserProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "UserProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "UserProfile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "UserProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "UserProfile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_UserProfile_ProfileId",
                table: "Bets",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserProfile_ProfileId",
                table: "Chats",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_UserProfile_ProfileId",
                table: "Massages",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserProfile_ProfileId",
                table: "Posts",
                column: "CreaterId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Clubs_ClubId",
                table: "UserProfile",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Fights_FightId",
                table: "UserProfile",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Clubs_ClubId",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Fights_FightId",
                table: "UserProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "UserProfile");

            migrationBuilder.RenameTable(
                name: "UserProfile",
                newName: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserProfiles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_FightId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_FightId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_ClubId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ProfileId",
                table: "Clubs",
                column: "CreaterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_UserProfiles_ProfileId",
                table: "Bets",
                column: "CreaterId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserProfiles_ProfileId",
                table: "Chats",
                column: "CreaterId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_UserProfiles_ProfileId",
                table: "Clubs",
                column: "CreaterId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Massages_UserProfiles_ProfileId",
                table: "Massages",
                column: "CreaterId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserProfiles_ProfileId",
                table: "Posts",
                column: "CreaterId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Clubs_ClubId",
                table: "UserProfiles",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Fights_FightId",
                table: "UserProfiles",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_IdentityUser_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }
    }
}
