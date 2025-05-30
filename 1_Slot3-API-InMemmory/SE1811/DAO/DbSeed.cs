namespace SE1811.DAO
{
    using Microsoft.EntityFrameworkCore;
    using SE1811.model;

    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Instruments",
                    Description = "Musical instruments category"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Electronics",
                    Description = "Electronic devices category"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Books",
                    Description = "All kinds of books"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                // Instruments
                new Product { ProductID = 1, NameProduct = "Guitar", DescriptionProduct = "Classic acoustic guitar", CategoryID = 1 },
                new Product { ProductID = 2, NameProduct = "Piano", DescriptionProduct = "88-key digital piano", CategoryID = 1 },
                new Product { ProductID = 3, NameProduct = "Drum Set", DescriptionProduct = "Standard 5-piece drum set", CategoryID = 1 },
                new Product { ProductID = 4, NameProduct = "Violin", DescriptionProduct = "Full size violin", CategoryID = 1 },
                new Product { ProductID = 5, NameProduct = "Flute", DescriptionProduct = "Silver concert flute", CategoryID = 1 },

                // Electronics
                new Product { ProductID = 6, NameProduct = "Canon Camera", DescriptionProduct = "DSLR professional", CategoryID = 2 },
                new Product { ProductID = 7, NameProduct = "Samsung Galaxy", DescriptionProduct = "Mobile phone", CategoryID = 2 },
                new Product { ProductID = 8, NameProduct = "MacBook Air", DescriptionProduct = "Apple laptop", CategoryID = 2 },
                new Product { ProductID = 9, NameProduct = "Logitech Mouse", DescriptionProduct = "Wireless", CategoryID = 2 },
                new Product { ProductID = 10, NameProduct = "HP Monitor", DescriptionProduct = "24-inch screen", CategoryID = 2 },

                // Books
                new Product { ProductID = 11, NameProduct = "C# Programming", DescriptionProduct = "Beginner to Advanced", CategoryID = 3 },
                new Product { ProductID = 12, NameProduct = "Clean Code", DescriptionProduct = "A Handbook of Agile Software Craftsmanship", CategoryID = 3 }
            );
        }
    }
}
