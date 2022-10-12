using Microsoft.EntityFrameworkCore;

namespace MemoryWebApi.Models
{
    public class PlayerContext: DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LocalHost;Initial Catalog=Memory;User Id=memorryapi;Password=password;TrustServerCertificate=True");
        }


    }
}
