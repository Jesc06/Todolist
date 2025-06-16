using Microsoft.EntityFrameworkCore;
using Todo_List_App.Models;
namespace Todo_List_App._DbContext
{
    public class TodoTable : DbContext
    {
        public TodoTable(DbContextOptions<TodoTable> options) : base(options) { }
        
        public DbSet<Todo> TodoData { get; set; }
    }
}
