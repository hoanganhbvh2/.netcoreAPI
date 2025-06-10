using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SE1811.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });

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
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookID", "Author", "AverageRating", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", 4.8m, 15.99m, "The Hobbit" },
                    { 2, "J.K. Rowling", 4.9m, 20.50m, "Harry Potter and the Philosopher's Stone" },
                    { 3, "F. Scott Fitzgerald", 4.3m, 12.99m, "The Great Gatsby" },
                    { 4, "Arthur Conan Doyle", 4.6m, 18.75m, "Adventure of Sherlock Holmes" },
                    { 5, "Jane Austen", 4.7m, 10.00m, "Pride and Prejudice" },
                    { 6, "J.R.R. Tolkien", 4.9m, 25.00m, "The Lord of the Rings" },
                    { 7, "George Orwell", 4.5m, 14.99m, "1984" },
                    { 8, "Harper Lee", 4.8m, 13.50m, "To Kill a Mockingbird" },
                    { 9, "J.D. Salinger", 4.2m, 11.99m, "The Catcher in the Rye" },
                    { 10, "Paulo Coelho", 4.4m, 16.50m, "The Alchemist" },
                    { 11, "Dan Brown", 4.1m, 19.99m, "The Da Vinci Code" },
                    { 12, "Stephen King", 4.6m, 17.75m, "The Shining" },
                    { 13, "Frank Herbert", 4.7m, 22.50m, "Dune" },
                    { 14, "Patrick Rothfuss", 4.8m, 21.00m, "The Name of the Wind" },
                    { 15, "C.S. Lewis", 4.6m, 15.00m, "The Chronicles of Narnia" },
                    { 16, "John Green", 4.3m, 12.50m, "The Fault in Our Stars" },
                    { 17, "Lois Lowry", 4.4m, 11.00m, "The Giver" },
                    { 18, "S.E. Hinton", 4.2m, 10.50m, "The Outsiders" },
                    { 19, "Suzanne Collins", 4.5m, 14.99m, "The Hunger Games" },
                    { 20, "Markus Zusak", 4.7m, 13.99m, "The Book Thief" }
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
                table: "Company",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "123 Silicon Street", "USA", "Tech Innovators" },
                    { 2, "456 Eco Ave", "Canada", "Green Solutions" },
                    { 3, "789 Wall Street", "UK", "Finance Pros" },
                    { 4, "101 Med Lane", "Germany", "Health Plus" },
                    { 5, "202 Knowledge Road", "France", "Edu Learn" },
                    { 6, "808 Vision Lane", "Netherlands", "Future Tech" },
                    { 7, "909 Innovation Ave", "Spain", "Smart Solutions" },
                    { 8, "1010 Secure Blvd", "South Korea", "Cyber Defense" },
                    { 9, "1010 Secure Blvd", "South Korea", "Cyber Defense" },
                    { 10, "1111 Web Street", "Brazil", "Digital Era" },
                    { 11, "1212 Green Road", "Sweden", "Sustainable Tech" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { 1, 30, 1, "Alice Johnson", "Developer" },
                    { 2, 35, 1, "Bob Smith", "Manager" },
                    { 3, 28, 2, "Charlie Brown", "Analyst" },
                    { 4, 40, 2, "David White", "Designer" },
                    { 5, 25, 3, "Eve Black", "Intern" },
                    { 6, 32, 4, "Franklin Harris", "Engineer" },
                    { 7, 29, 4, "Grace Miller", "Consultant" },
                    { 8, 45, 3, "Henry Ford", "CEO" },
                    { 9, 27, 4, "Ivy Green", "Marketing" },
                    { 10, 38, 5, "Jack Wilson", "Finance" }
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
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
