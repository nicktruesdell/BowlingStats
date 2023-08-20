using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class BowlingContext : DbContext, IBowlingContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }

        public BowlingContext(DbContextOptions options) : base(options)
        {
        }
    }
}