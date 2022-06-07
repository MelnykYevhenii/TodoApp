using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.db
{
    public class AppDBContext : DbContext
    {
        public DbSet<Exercise> TodoTask { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option) => Database.EnsureCreated();
    }
}
