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
    }
}
