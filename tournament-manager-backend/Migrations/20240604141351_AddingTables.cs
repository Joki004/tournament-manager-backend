using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tournament_manager_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    DisciplineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayersPerTeam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.DisciplineID);
                });

            migrationBuilder.CreateTable(
                name: "TournamentTypes",
                columns: table => new
                {
                    TournamentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTypes", x => x.TournamentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BracketMatches",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentID = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Team1ID = table.Column<int>(type: "int", nullable: false),
                    Team2ID = table.Column<int>(type: "int", nullable: false),
                    WinnerTeamID = table.Column<int>(type: "int", nullable: true),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BracketMatches", x => x.MatchID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "RoundRobinMatches",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentID = table.Column<int>(type: "int", nullable: false),
                    Team1ID = table.Column<int>(type: "int", nullable: false),
                    Team2ID = table.Column<int>(type: "int", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: true),
                    Team2Score = table.Column<int>(type: "int", nullable: true),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundRobinMatches", x => x.MatchID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentID = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisciplineID = table.Column<int>(type: "int", nullable: false),
                    TournamentTypeID = table.Column<int>(type: "int", nullable: false),
                    NumberOfTeams = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WinnerTeamID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                    table.ForeignKey(
                        name: "FK_Tournaments_Disciplines_DisciplineID",
                        column: x => x.DisciplineID,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournaments_Teams_WinnerTeamID",
                        column: x => x.WinnerTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournaments_TournamentTypes_TournamentTypeID",
                        column: x => x.TournamentTypeID,
                        principalTable: "TournamentTypes",
                        principalColumn: "TournamentTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournaments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BracketMatches_Team1ID",
                table: "BracketMatches",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_BracketMatches_Team2ID",
                table: "BracketMatches",
                column: "Team2ID");

            migrationBuilder.CreateIndex(
                name: "IX_BracketMatches_TournamentID",
                table: "BracketMatches",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_BracketMatches_WinnerTeamID",
                table: "BracketMatches",
                column: "WinnerTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundRobinMatches_Team1ID",
                table: "RoundRobinMatches",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundRobinMatches_Team2ID",
                table: "RoundRobinMatches",
                column: "Team2ID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundRobinMatches_TournamentID",
                table: "RoundRobinMatches",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TournamentID",
                table: "Teams",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_DisciplineID",
                table: "Tournaments",
                column: "DisciplineID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentTypeID",
                table: "Tournaments",
                column: "TournamentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_UserID",
                table: "Tournaments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_WinnerTeamID",
                table: "Tournaments",
                column: "WinnerTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_BracketMatches_Teams_Team1ID",
                table: "BracketMatches",
                column: "Team1ID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BracketMatches_Teams_Team2ID",
                table: "BracketMatches",
                column: "Team2ID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BracketMatches_Teams_WinnerTeamID",
                table: "BracketMatches",
                column: "WinnerTeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BracketMatches_Tournaments_TournamentID",
                table: "BracketMatches",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundRobinMatches_Teams_Team1ID",
                table: "RoundRobinMatches",
                column: "Team1ID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundRobinMatches_Teams_Team2ID",
                table: "RoundRobinMatches",
                column: "Team2ID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundRobinMatches_Tournaments_TournamentID",
                table: "RoundRobinMatches",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tournaments_TournamentID",
                table: "Teams",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Teams_WinnerTeamID",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "BracketMatches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "RoundRobinMatches");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "TournamentTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
