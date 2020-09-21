using Diamond.Models;
using Microsoft.EntityFrameworkCore;

namespace Diamond.Data
{
    public class DiamondContext : DbContext
    {
        public DiamondContext(DbContextOptions<DiamondContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Prodotto> Prodotto { get; set; }

        public DbSet<Reparto> Reparto { get; set; }
    }
}