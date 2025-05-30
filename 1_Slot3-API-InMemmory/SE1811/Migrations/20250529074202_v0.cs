using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SE1811.Migrations
{
    /// <inheritdoc />
    public partial class v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Instruments", "Musical instruments category" },
                    { 2, "Electronics", "Electronic devices category" },
                    { 3, "Books", "All kinds of books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "DescriptionProduct", "NameProduct", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Classic acoustic guitar", "Guitar", 0 },
                    { 2, 1, "88-key digital piano", "Piano", 0 },
                    { 3, 1, "Standard 5-piece drum set", "Drum Set", 0 },
                    { 4, 1, "Full size violin", "Violin", 0 },
                    { 5, 1, "Silver concert flute", "Flute", 0 },
                    { 6, 2, "DSLR professional", "Canon Camera", 0 },
                    { 7, 2, "Mobile phone", "Samsung Galaxy", 0 },
                    { 8, 2, "Apple laptop", "MacBook Air", 0 },
                    { 9, 2, "Wireless", "Logitech Mouse", 0 },
                    { 10, 2, "24-inch screen", "HP Monitor", 0 },
                    { 11, 3, "Beginner to Advanced", "C# Programming", 0 },
                    { 12, 3, "A Handbook of Agile Software Craftsmanship", "Clean Code", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
