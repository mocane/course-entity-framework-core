using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data
{
    public class FotballLeagueDbContext : DbContext
    {
        private readonly string Dbpath;

        public FotballLeagueDbContext()
        {
            Dbpath = System.IO.Path.Join(AppContext.BaseDirectory, "FootballLeague.db");
        }
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Dbpath}")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var createdUtc = new DateTime(2026, 04, 16, 16, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Tivoli", CreatedDate = createdUtc },
                new Team { Id = 2, Name = "Rosenborg", CreatedDate = createdUtc },
                new Team { Id = 3, Name = "Brann", CreatedDate = createdUtc });
        }
    }
}
