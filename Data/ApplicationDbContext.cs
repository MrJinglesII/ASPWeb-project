using Microsoft.EntityFrameworkCore;
using project.Models;
namespace project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            Database.EnsureCreated();
        }

        public DbSet<Miniatures> Miniatures { get; set; }
    }
}
