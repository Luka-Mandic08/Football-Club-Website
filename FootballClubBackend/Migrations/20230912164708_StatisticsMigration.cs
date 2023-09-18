using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class StatisticsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.CreateTable(
                name: "AttackingStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalShots = table.Column<int>(type: "int", nullable: false),
                    ShotsOnTarget = table.Column<int>(type: "int", nullable: false),
                    TotalGoals = table.Column<int>(type: "int", nullable: false),
                    RightFootedGoals = table.Column<int>(type: "int", nullable: false),
                    LeftFootedGoals = table.Column<int>(type: "int", nullable: false),
                    HeadedGoals = table.Column<int>(type: "int", nullable: false),
                    FreekickGoals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackingStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefendingStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clearances = table.Column<int>(type: "int", nullable: false),
                    Blocks = table.Column<int>(type: "int", nullable: false),
                    Interception = table.Column<int>(type: "int", nullable: false),
                    TackleSuccessRate = table.Column<float>(type: "real", nullable: false),
                    AerialDuelSuccessRate = table.Column<float>(type: "real", nullable: false),
                    GroundDuelSuccessRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefendingStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    Starts = table.Column<int>(type: "int", nullable: false),
                    SubbedOff = table.Column<int>(type: "int", nullable: false),
                    FoulsWon = table.Column<int>(type: "int", nullable: false),
                    FoulsConceded = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoalkeepingStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfSaves = table.Column<int>(type: "int", nullable: false),
                    SavePercentage = table.Column<float>(type: "real", nullable: false),
                    CleanSheets = table.Column<int>(type: "int", nullable: false),
                    PenaltiesSaved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalkeepingStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassingStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPasses = table.Column<int>(type: "int", nullable: false),
                    CompletedPasses = table.Column<int>(type: "int", nullable: false),
                    TotalLongPasses = table.Column<int>(type: "int", nullable: false),
                    CompletedLongPasses = table.Column<int>(type: "int", nullable: false),
                    CompletedCrosses = table.Column<int>(type: "int", nullable: false),
                    SecondAssists = table.Column<int>(type: "int", nullable: false),
                    KeyPasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassingStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Competition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralStatisticsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassingStatisticsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalkeepingStatisticsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefendingStatisticsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttackingStatisticsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_AttackingStatistics_AttackingStatisticsId",
                        column: x => x.AttackingStatisticsId,
                        principalTable: "AttackingStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_DefendingStatistics_DefendingStatisticsId",
                        column: x => x.DefendingStatisticsId,
                        principalTable: "DefendingStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_GeneralStatistics_GeneralStatisticsId",
                        column: x => x.GeneralStatisticsId,
                        principalTable: "GeneralStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_GoalkeepingStatistics_GoalkeepingStatisticsId",
                        column: x => x.GoalkeepingStatisticsId,
                        principalTable: "GoalkeepingStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_PassingStatistics_PassingStatisticsId",
                        column: x => x.PassingStatisticsId,
                        principalTable: "PassingStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_AttackingStatisticsId",
                table: "PlayerStatistics",
                column: "AttackingStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_DefendingStatisticsId",
                table: "PlayerStatistics",
                column: "DefendingStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_GeneralStatisticsId",
                table: "PlayerStatistics",
                column: "GeneralStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_GoalkeepingStatisticsId",
                table: "PlayerStatistics",
                column: "GoalkeepingStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_PassingStatisticsId",
                table: "PlayerStatistics",
                column: "PassingStatisticsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStatistics");

            migrationBuilder.DropTable(
                name: "AttackingStatistics");

            migrationBuilder.DropTable(
                name: "DefendingStatistics");

            migrationBuilder.DropTable(
                name: "GeneralStatistics");

            migrationBuilder.DropTable(
                name: "GoalkeepingStatistics");

            migrationBuilder.DropTable(
                name: "PassingStatistics");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }
    }
}
