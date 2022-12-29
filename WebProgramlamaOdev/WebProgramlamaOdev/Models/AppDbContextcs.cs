using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebProgramlamaOdev.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Filmler> Filmler { get; set; }


    }
}
