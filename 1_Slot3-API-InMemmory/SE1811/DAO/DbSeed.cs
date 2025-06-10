namespace SE1811.DAO
{
    using Entity.model;
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

            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", Price = 15.99M, AverageRating = 4.8M },
                new Book { BookID = 2, Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Price = 20.50M, AverageRating = 4.9M },
                new Book { BookID = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 12.99M, AverageRating = 4.3M },
                new Book { BookID = 4, Title = "Adventure of Sherlock Holmes", Author = "Arthur Conan Doyle", Price = 18.75M, AverageRating = 4.6M },
                new Book { BookID = 5, Title = "Pride and Prejudice", Author = "Jane Austen", Price = 10.00M, AverageRating = 4.7M },
                new Book { BookID = 6, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Price = 25.00M, AverageRating = 4.9M },
                new Book { BookID = 7, Title = "1984", Author = "George Orwell", Price = 14.99M, AverageRating = 4.5M },
                new Book { BookID = 8, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 13.50M, AverageRating = 4.8M },
                new Book { BookID = 9, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Price = 11.99M, AverageRating = 4.2M },
                new Book { BookID = 10, Title = "The Alchemist", Author = "Paulo Coelho", Price = 16.50M, AverageRating = 4.4M },
                new Book { BookID = 11, Title = "The Da Vinci Code", Author = "Dan Brown", Price = 19.99M, AverageRating = 4.1M },
                new Book { BookID = 12, Title = "The Shining", Author = "Stephen King", Price = 17.75M, AverageRating = 4.6M },
                new Book { BookID = 13, Title = "Dune", Author = "Frank Herbert", Price = 22.50M, AverageRating = 4.7M },
                new Book { BookID = 14, Title = "The Name of the Wind", Author = "Patrick Rothfuss", Price = 21.00M, AverageRating = 4.8M },
                new Book { BookID = 15, Title = "The Chronicles of Narnia", Author = "C.S. Lewis", Price = 15.00M, AverageRating = 4.6M },
                new Book { BookID = 16, Title = "The Fault in Our Stars", Author = "John Green", Price = 12.50M, AverageRating = 4.3M },
                new Book { BookID = 17, Title = "The Giver", Author = "Lois Lowry", Price = 11.00M, AverageRating = 4.4M },
                new Book { BookID = 18, Title = "The Outsiders", Author = "S.E. Hinton", Price = 10.50M, AverageRating = 4.2M },
                new Book { BookID = 19, Title = "The Hunger Games", Author = "Suzanne Collins", Price = 14.99M, AverageRating = 4.5M },
                new Book { BookID = 20, Title = "The Book Thief", Author = "Markus Zusak", Price = 13.99M, AverageRating = 4.7M });
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
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Tech Innovators", Address = "123 Silicon Street", Country = "USA" },
                new Company { Id = 2, Name = "Green Solutions", Address = "456 Eco Ave", Country = "Canada" },
                new Company { Id = 3, Name = "Finance Pros", Address = "789 Wall Street", Country = "UK" },
                new Company { Id = 4, Name = "Health Plus", Address = "101 Med Lane", Country = "Germany" },
                new Company { Id = 5, Name = "Edu Learn", Address = "202 Knowledge Road", Country = "France" },
                new Company { Id=6, Name = "Future Tech", Address = "808 Vision Lane", Country = "Netherlands" },
                new Company { Id = 7, Name = "Smart Solutions", Address = "909 Innovation Ave", Country = "Spain" },
                new Company { Id = 8, Name = "Cyber Defense", Address = "1010 Secure Blvd", Country = "South Korea" },
                new Company { Id = 9, Name = "Cyber Defense", Address = "1010 Secure Blvd", Country = "South Korea" },
                new Company { Id = 10, Name = "Digital Era", Address = "1111 Web Street", Country = "Brazil" },
                new Company { Id = 11, Name = "Sustainable Tech", Address = "1212 Green Road", Country = "Sweden" }
);


            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Alice Johnson", Age = 30, Position = "Developer", CompanyId = 1},
                new Employee { Id = 2, Name = "Bob Smith", Age = 35, Position = "Manager", CompanyId = 1 },
                new Employee { Id = 3, Name = "Charlie Brown", Age = 28, Position = "Analyst", CompanyId = 2 },
                new Employee { Id = 4, Name = "David White", Age = 40, Position = "Designer", CompanyId =2},
                new Employee { Id = 5, Name = "Eve Black", Age = 25, Position = "Intern", CompanyId =3 },
                new Employee { Id = 6, Name = "Franklin Harris", Age = 32, Position = "Engineer", CompanyId =4},
                new Employee { Id = 7, Name = "Grace Miller", Age = 29, Position = "Consultant", CompanyId = 4},
                new Employee { Id = 8, Name = "Henry Ford", Age = 45, Position = "CEO", CompanyId = 3 },
                new Employee { Id = 9, Name = "Ivy Green", Age = 27, Position = "Marketing", CompanyId = 4 },
                new Employee { Id = 10, Name = "Jack Wilson", Age = 38, Position = "Finance", CompanyId = 5 }
            );

        }
    }
}
