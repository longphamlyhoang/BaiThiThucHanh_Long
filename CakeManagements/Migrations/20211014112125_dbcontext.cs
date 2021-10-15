using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeManagements.Migrations
{
    public partial class dbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    CakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CakeName = table.Column<string>(nullable: false),
                    Ingredient = table.Column<string>(nullable: false),
                    Expiry = table.Column<string>(nullable: false),
                    DateOfManufacture = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.CakeId);
                    table.ForeignKey(
                        name: "FK_Cakes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Cake 1" },
                    { 2, "Cake 2" },
                    { 3, "Cake 3" },
                    { 4, "Cake 4" },
                    { 5, "Cake 5" }
                });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "CakeId", "CakeName", "CategoryId", "DateOfManufacture", "Deleted", "Expiry", "Ingredient", "Price" },
                values: new object[] { 1, "cake 12", 1, "03-10-2021", false, "3 ngày", "bột_đường", 12 });

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CategoryId",
                table: "Cakes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
