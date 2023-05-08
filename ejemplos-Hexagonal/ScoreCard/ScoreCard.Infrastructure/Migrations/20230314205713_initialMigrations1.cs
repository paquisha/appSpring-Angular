using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreCard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSecretInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClientSecret = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ApplicationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSecretInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSecretInformation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityScoreSnapshot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnapshotDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityScoreSnapshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityScoreSnapshot_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlRecommendationId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlRemediationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SecureScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecurityScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlRecommendationId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlRecommendationId_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                        column: x => x.SecurityScoreSnapshotId,
                        principalTable: "SecurityScoreSnapshot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecureScore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tenantid = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PercentageScore = table.Column<decimal>(type: "decimal(18,2)", maxLength: 255, nullable: false),
                    CurrentScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    SecureScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecurityScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecureScore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecureScore_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                        column: x => x.SecurityScoreSnapshotId,
                        principalTable: "SecurityScoreSnapshot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecurityPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AzureDefenderPlan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SecureScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecurityScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityPlan_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                        column: x => x.SecurityScoreSnapshotId,
                        principalTable: "SecurityScoreSnapshot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecurityScoreControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ControlName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ControlId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UnhealthyResourceCount = table.Column<int>(type: "int", nullable: false),
                    HealthyResourceCount = table.Column<int>(type: "int", nullable: false),
                    NotAppliclableResourceCount = table.Column<int>(type: "int", nullable: false),
                    PercentageScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    ControlType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SecureScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecurityScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityScoreControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityScoreControl_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                        column: x => x.SecurityScoreSnapshotId,
                        principalTable: "SecurityScoreSnapshot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecurityStandard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ComplianceStandard = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PassedControl = table.Column<int>(type: "int", nullable: false),
                    FailControl = table.Column<int>(type: "int", nullable: false),
                    UnsupportedControl = table.Column<int>(type: "int", nullable: false),
                    SecureScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecurityScoreSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityStandard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityStandard_SecurityScoreSnapshot_SecurityScoreSnapshotId",
                        column: x => x.SecurityScoreSnapshotId,
                        principalTable: "SecurityScoreSnapshot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlRecommendationId_SecurityScoreSnapshotId",
                table: "ControlRecommendationId",
                column: "SecurityScoreSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSecretInformation_CustomerId",
                table: "CustomerSecretInformation",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecureScore_SecurityScoreSnapshotId",
                table: "SecureScore",
                column: "SecurityScoreSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityPlan_SecurityScoreSnapshotId",
                table: "SecurityPlan",
                column: "SecurityScoreSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityScoreControl_SecurityScoreSnapshotId",
                table: "SecurityScoreControl",
                column: "SecurityScoreSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityScoreSnapshot_SubscriptionId",
                table: "SecurityScoreSnapshot",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityStandard_SecurityScoreSnapshotId",
                table: "SecurityStandard",
                column: "SecurityScoreSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CustomerId",
                table: "Subscription",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlRecommendationId");

            migrationBuilder.DropTable(
                name: "CustomerSecretInformation");

            migrationBuilder.DropTable(
                name: "SecureScore");

            migrationBuilder.DropTable(
                name: "SecurityPlan");

            migrationBuilder.DropTable(
                name: "SecurityScoreControl");

            migrationBuilder.DropTable(
                name: "SecurityStandard");

            migrationBuilder.DropTable(
                name: "SecurityScoreSnapshot");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
