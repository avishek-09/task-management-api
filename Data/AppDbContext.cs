using Microsoft.EntityFrameworkCore; 
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Datas;

public class AppDbContext : DbContext  // AppDbContext is like a bridge between C# application n Db.
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoTask> TodoTasks {get; set; } // this EF core i want a db table representning my TodoTask entities.
}
