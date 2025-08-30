using Microsoft.EntityFrameworkCore;
using TaskManagerConnector.Model;

namespace TaskManagerConnector.Databases
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; } = default!;
    }
}
