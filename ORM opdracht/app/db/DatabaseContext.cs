using Microsoft.EntityFrameworkCore;
namespace admin
{

    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Gebruiker> Gebruikers { get; set; }

        public DbSet<Gast> Gasten {get;set; }

    }
}
