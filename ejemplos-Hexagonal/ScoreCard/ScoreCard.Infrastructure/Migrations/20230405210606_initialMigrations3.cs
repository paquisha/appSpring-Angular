using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreCard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlRecommendationId_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "ControlRecommendationId");

            migrationBuilder.DropForeignKey(
                name: "FK_SecureScore_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecureScore");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityPlan_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityScoreControl_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityScoreControl");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityStandard_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityStandard");

            migrationBuilder.DropColumn(
                name: "SecureScoreSnapshotId",
                table: "SecurityStandard");

            migrationBuilder.DropColumn(
                name: "SecureScoreSnapshotId",
                table: "SecurityScoreControl");

            migrationBuilder.DropColumn(
                name: "SecureScoreSnapshotId",
                table: "SecurityPlan");

            migrationBuilder.DropColumn(
                name: "SecureScoreSnapshotId",
                table: "SecureScore");

            migrationBuilder.DropColumn(
                name: "SecureScoreSnapshotId",
                table: "ControlRecommendationId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecurityStandard",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecurityScoreControl",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecurityPlan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecureScore",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "ControlRecommendationId",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlRecommendationId_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "ControlRecommendationId",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecureScore_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecureScore",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityPlan_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityPlan",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityScoreControl_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityScoreControl",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityStandard_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityStandard",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlRecommendationId_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "ControlRecommendationId");

            migrationBuilder.DropForeignKey(
                name: "FK_SecureScore_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecureScore");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityPlan_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityScoreControl_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityScoreControl");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityStandard_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityStandard");

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecurityStandard",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SecureScoreSnapshotId",
                table: "SecurityStandard",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecurityScoreControl",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SecureScoreSnapshotId",
                table: "SecurityScoreControl",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecurityPlan",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SecureScoreSnapshotId",
                table: "SecurityPlan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "SecureScore",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SecureScoreSnapshotId",
                table: "SecureScore",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SecurityScoreSnapshotId",
                table: "ControlRecommendationId",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SecureScoreSnapshotId",
                table: "ControlRecommendationId",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ControlRecommendationId_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "ControlRecommendationId",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SecureScore_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecureScore",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityPlan_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityPlan",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityScoreControl_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityScoreControl",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityStandard_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                table: "SecurityStandard",
                column: "SecurityScoreSnapshotId",
                principalTable: "SecurityScoreSnapshot",
                principalColumn: "Id");
        }
    }
}
