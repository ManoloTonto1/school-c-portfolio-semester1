using Microsoft.EntityFrameworkCore;
namespace admin
{

    public class DatabaseContext : DbContext
    {
        public DbSet<Gast> Gasten { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<OnderHoud> OnderHouden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER02;Database=ORMProject;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gast
            modelBuilder.Entity<Gast>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Gast>()
                .HasOne(g => g.info)
                .WithOne(gi => gi.gast)
                .HasForeignKey<Gast>(g => g.gastInfoId);

            modelBuilder.Entity<Gast>()
                .HasMany(g => g.reserveringen)
                .WithOne(r => r.gast);

            modelBuilder.Entity<Gast>()
                .HasOne(g => g.FavoriteAttractie)
                .WithMany(a => a.gastenFav);

            // Medewerker
            modelBuilder.Entity<Medewerker>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<Medewerker>()
                .HasMany(m => m.onderhoudenTeCoordineren)
                .WithMany(o => o.coordinatoren);

            modelBuilder.Entity<Medewerker>()
                .HasMany(m => m.onderhoudenTeDoen)
                .WithMany(o => o.medewerkers);

            modelBuilder.Entity<GastInfo>()
                .HasKey(gi => gi.Id);
            modelBuilder.Entity<GastInfo>()
                .OwnsOne(gi => gi.coordinate);

            modelBuilder.Entity<OnderHoud>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OnderHoud>()
                .HasOne(o => o.attractieOmTeOnderhouden)
                .WithMany(a => a.onderHouden);

            modelBuilder.Entity<OnderHoud>()
                .OwnsOne(o => o.datumonderhoud);

        }
    }
}
