using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _03_03_Rhythms_Gonna_Get_You
{
    class BandDatabaseContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Band-Database");
            // var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            // optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
