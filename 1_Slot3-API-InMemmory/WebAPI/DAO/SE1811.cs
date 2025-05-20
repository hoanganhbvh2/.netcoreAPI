using Microsoft.EntityFrameworkCore;
using WebAPI.model;

namespace WebAPI.DAO
{
    public class SE1811 : DbContext
    {
        // khai bao ham khoi tao
        public SE1811(DbContextOptions options) : base(options)
        {
        }
        // khai bao entity dung de ket noi database / anh xa  voi database
       public DbSet<Product> Products { get; set; }
    }
}
