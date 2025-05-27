namespace SE1811.DAO
{
    using Microsoft.EntityFrameworkCore;
    using SE1811.model;
    using System;

    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed bảng Product
            //modelBuilder.Entity<Product>().HasData(
            //    new Product { ProductID = 1, NameProduct = "Guitar", DescriptionProduct = "Classic acoustic guitar",CategoryID=1 },
            //    new Product { ProductID = 2, NameProduct = "Piano", DescriptionProduct = "88-key digital piano", CategoryID = 1 },
            //    new Product { ProductID = 3, NameProduct = "Drum Set", DescriptionProduct = "Standard 5-piece drum set", CategoryID = 1 },
            //    new Product { ProductID = 4, NameProduct = "Violin", DescriptionProduct = "Full size violin", CategoryID = 1 },
            //    new Product { ProductID = 5, NameProduct = "Flute", DescriptionProduct = "Silver concert flute", CategoryID = 1 }
            //);
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, NameProduct = "Guitar", DescriptionProduct = "Classic acoustic guitar", CategoryID = 1 }
);
        }
    }
}
