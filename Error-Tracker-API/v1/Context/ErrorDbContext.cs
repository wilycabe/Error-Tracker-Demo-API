using Error_Tracker_API.v1.Entity;
using Microsoft.EntityFrameworkCore;

namespace Error_Tracker_API.v1.Context
{
    public class ErrorDbContext : DbContext
    {
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        public ErrorDbContext(DbContextOptions<ErrorDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLog>().HasKey(e => e.Id);
        }
    }
}
