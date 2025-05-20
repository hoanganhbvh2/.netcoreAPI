using Microsoft.EntityFrameworkCore;
using WebAPI.model;

namespace WebAPI.DAO
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {

        }
        // khai bao entity cho my context
        public DbSet<TodoItem> todoList { set; get; }
        // do du lieu mau vao
        
    }
}
