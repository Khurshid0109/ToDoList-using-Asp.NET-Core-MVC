using Microsoft.EntityFrameworkCore;
using ToDo_List_With_MVC.Models;

namespace ToDo_List_With_MVC.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
