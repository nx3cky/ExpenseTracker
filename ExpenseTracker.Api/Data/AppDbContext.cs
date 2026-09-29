using ExpenseTracker.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
