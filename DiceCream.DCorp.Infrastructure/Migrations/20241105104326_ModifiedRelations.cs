using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceCream.DCorp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_PlayerProfiles_PlayerProfilesId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "SessionParticipant");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_PlayerProfilesId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "PlayerProfilesId",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerProfileSession",
                columns: table => new
                {
                    ParticipantsId = table.Column<int>(type: "int", nullable: false),
                    SessionHistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfileSession", x => new { x.ParticipantsId, x.SessionHistoryId });
                    table.ForeignKey(
                        name: "FK_PlayerProfileSession_PlayerProfiles_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "PlayerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerProfileSession_Sessions_SessionHistoryId",
                        column: x => x.SessionHistoryId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfileSession_SessionHistoryId",
                table: "PlayerProfileSession",
                column: "SessionHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AspNetUsers_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AspNetUsers_UserId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "PlayerProfileSession");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "PlayerProfilesId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SessionParticipant",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionParticipant", x => new { x.SessionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SessionParticipant_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionParticipant_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_PlayerProfilesId",
                table: "Sessions",
                column: "PlayerProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionParticipant_UserId",
                table: "SessionParticipant",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_PlayerProfiles_PlayerProfilesId",
                table: "Sessions",
                column: "PlayerProfilesId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
