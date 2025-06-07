using Microsoft.EntityFrameworkCore;
using SE1811.model;

namespace SE1811.DAO
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Book { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ 1-N giữa Category và Product (nếu muốn)
         modelBuilder.Entity<Product>()
         .HasOne(p => p.Category)
         .WithMany(c => c.Products)
         .HasForeignKey(p => p.CategoryID)
         .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Seed();

        }
    }
}
