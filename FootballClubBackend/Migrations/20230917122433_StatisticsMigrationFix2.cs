using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballClubBackend.Migrations
{
    /// <inheritdoc />
    public partial class StatisticsMigrationFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_AttackingStatistics_AttackingStatisticsId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_DefendingStatistics_DefendingStatisticsId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_GoalkeepingStatistics_GoalkeepingStatisticsId",
                table: "PlayerStatistics");

            migrationBuilder.AlterColumn<Guid>(
                name: "GoalkeepingStatisticsId",
                table: "PlayerStatistics",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DefendingStatisticsId",
                table: "PlayerStatistics",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttackingStatisticsId",
                table: "PlayerStatistics",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_AttackingStatistics_AttackingStatisticsId",
                table: "PlayerStatistics",
                column: "AttackingStatisticsId",
                principalTable: "AttackingStatistics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_DefendingStatistics_DefendingStatisticsId",
                table: "PlayerStatistics",
                column: "DefendingStatisticsId",
                principalTable: "DefendingStatistics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_GoalkeepingStatistics_GoalkeepingStatisticsId",
                table: "PlayerStatistics",
                column: "GoalkeepingStatisticsId",
                principalTable: "GoalkeepingStatistics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_AttackingStatistics_AttackingStatisticsId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_DefendingStatistics_DefendingStatisticsId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_GoalkeepingStatistics_GoalkeepingStatisticsId",
                table: "PlayerStatistics");

            migrationBuilder.AlterColumn<Guid>(
                name: "GoalkeepingStatisticsId",
                table: "PlayerStatistics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DefendingStatisticsId",
                table: "PlayerStatistics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AttackingStatisticsId",
                table: "PlayerStatistics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_AttackingStatistics_AttackingStatisticsId",
                table: "PlayerStatistics",
                column: "AttackingStatisticsId",
                principalTable: "AttackingStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_DefendingStatistics_DefendingStatisticsId",
                table: "PlayerStatistics",
                column: "DefendingStatisticsId",
                principalTable: "DefendingStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_GoalkeepingStatistics_GoalkeepingStatisticsId",
                table: "PlayerStatistics",
                column: "GoalkeepingStatisticsId",
                principalTable: "GoalkeepingStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
