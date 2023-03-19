using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Fights_FightId",
                table: "UserProfile");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_FightId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "CashAccount",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "FightId",
                table: "UserProfile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CashAccount",
                table: "UserProfile",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "FightId",
                table: "UserProfile",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CloseBet = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartAtFight = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<string>(type: "text", nullable: false),
                    FightId = table.Column<Guid>(type: "uuid", nullable: true),
                    Money = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bets_Fights_FightId",
                        column: x => x.FightId,
                        principalTable: "Fights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bets_UserProfile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_FightId",
                table: "UserProfile",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_FightId",
                table: "Bets",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_ProfileId",
                table: "Bets",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Fights_FightId",
                table: "UserProfile",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id");
        }
    }
}
