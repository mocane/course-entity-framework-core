using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    public class FotballLeagueDbContext : DbContext
    {
        private string Dbpath;

        public FotballLeagueDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Dbpath = System.IO.Path.Join(path, "FotballLeague.db");
        }
        
        public DbSet<Team> Teams { get; set; }
        
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=FotballLeague.db");
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
