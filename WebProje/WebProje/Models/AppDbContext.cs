using Microsoft.EntityFrameworkCore;

namespace WebProje.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }

        public DbSet<Filmler> Filmler { get; set; }


    }
}
