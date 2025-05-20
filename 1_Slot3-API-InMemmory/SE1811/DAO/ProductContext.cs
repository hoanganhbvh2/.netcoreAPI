using Microsoft.EntityFrameworkCore;
using SE1811.model;

namespace SE1811.DAO
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        protected ProductContext()
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
