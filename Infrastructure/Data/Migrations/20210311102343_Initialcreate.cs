using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DinnerTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderAggregates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<long>(nullable: false),
                    Subtotal = table.Column<double>(nullable: false),
                    BuyerEmail = table.Column<string>(nullable: true),
                    PaymentIntentId = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAggregates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuOrdered_MenuName = table.Column<string>(nullable: true),
                    MenuOrdered_MenuDay = table.Column<int>(nullable: true),
                    MenuOrdered_MenuMonth = table.Column<int>(nullable: true),
                    MenuOrdered_MenuYear = table.Column<int>(nullable: true),
                    MenuOrdered_SchoolName = table.Column<string>(nullable: true),
                    MenuOrdered_DinnerTime = table.Column<string>(nullable: true),
                    Price = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    OrderAggregateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_OrderAggregates_OrderAggregateId",
                        column: x => x.OrderAggregateId,
                        principalTable: "OrderAggregates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DinnerTimeId = table.Column<int>(nullable: false),
                    FoodFirst = table.Column<string>(nullable: true),
                    FoodSecond = table.Column<string>(nullable: true),
                    FoodThird = table.Column<string>(nullable: true),
                    FoodFourth = table.Column<string>(nullable: true),
                    SchoolNameId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    Holiday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_DinnerTimes_DinnerTimeId",
                        column: x => x.DinnerTimeId,
                        principalTable: "DinnerTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_SchoolNames_SchoolNameId",
                        column: x => x.SchoolNameId,
                        principalTable: "SchoolNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OrderAggregateId",
                table: "MenuItems",
                column: "OrderAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_DinnerTimeId",
                table: "Menus",
                column: "DinnerTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SchoolNameId",
                table: "Menus",
                column: "SchoolNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "OrderAggregates");

            migrationBuilder.DropTable(
                name: "DinnerTimes");

            migrationBuilder.DropTable(
                name: "SchoolNames");
        }
    }
}
