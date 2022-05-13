using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    public partial class InitialCreateDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    CostumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostumerName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.CostumerId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "OrderMaters",
                columns: table => new
                {
                    OrderMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    CostumerId = table.Column<int>(type: "int", nullable: false),
                    PMethod = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    GTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMaters", x => x.OrderMasterId);
                    table.ForeignKey(
                        name: "FK_OrderMaters_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "CostumerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderMasterId = table.Column<long>(type: "bigint", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    FoodItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderMaters_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "OrderMaters",
                        principalColumn: "OrderMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FoodItemId",
                table: "OrderDetails",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderMasterId",
                table: "OrderDetails",
                column: "OrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaters_CostumerId",
                table: "OrderMaters",
                column: "CostumerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "OrderMaters");

            migrationBuilder.DropTable(
                name: "Costumers");
        }
    }
}
