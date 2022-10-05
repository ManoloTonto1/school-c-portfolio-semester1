using Microsoft.EntityFrameworkCore;
namespace admin
{

    public class DatabaseContext : DbContext
    {
        

        public async Task<bool> Boek(Gast gast, Attractie attractie, DateTimeBereik dateTimeBereik)
        {

            var isVrij = await new Attractie().Vrij(this, dateTimeBereik);

            if (!isVrij) return false;

            // alter the field
            gast.Credits = gast.Credits - 1;
            gast.reserveringen.Add(new Reservering(attractie, dateTimeBereik, gast));

            try
            {
                // begin the transaction
                Gasten.Attach(gast);
                Entry(gast).Property(g => g.reserveringen).IsModified = true;
                Entry(gast).Property(g => g.Credits).IsModified = true;
                SaveChanges();
                // return true if it was successfull
                return true;
            }
            catch
            {

                return false;
            }
        }

        // Setup
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Gast> Gasten { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<OnderHoud> OnderHouden { get; set; }
        public DbSet<Attractie> Attracties { get; set; }
        public DbSet<DateTimeBereik> DateTimeBereiken { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER02;Database=ORMProject;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tables
            modelBuilder.Entity<Gebruiker>()
                .ToTable("Gebruikers");
            modelBuilder.Entity<Gast>()
                .ToTable("Gasten");
            modelBuilder.Entity<Medewerker>()
                .ToTable("Medewerkers");

            //gerbuiker
            modelBuilder.Entity<Gebruiker>()
                .HasKey(g => g.Id);

            // Gast
            modelBuilder.Entity<Gast>()
                .HasOne(g => g.info)
                .WithOne(gi => gi.gast)
                .HasForeignKey<Gast>(g => g.gastInfoID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Gast>()
                .HasOne(g => g.begeleider);

            modelBuilder.Entity<Gast>()
                .HasMany(g => g.reserveringen)
                .WithOne(r => r.gast);

            modelBuilder.Entity<Gast>()
                .HasOne(g => g.FavoriteAttractie)
                .WithMany(a => a.gastenFav);

            // Medewerker
            modelBuilder.Entity<Medewerker>()
                .HasMany(m => m.onderhoudenTeCoordineren)
                .WithMany(o => o.coordinatoren)
                .UsingEntity("OnderhoudenTeCoordineren");

            modelBuilder.Entity<Medewerker>()
                .HasMany(m => m.onderhoudenTeDoen)
                .WithMany(o => o.medewerkers)
                .UsingEntity("OnderhoudenTeDoen");

            // GastInfo
            modelBuilder.Entity<GastInfo>()
                .HasKey(gi => gi.Id);
            modelBuilder.Entity<GastInfo>()
                .OwnsOne(gi => gi.coordinate);


            // Onderhoud
            modelBuilder.Entity<OnderHoud>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OnderHoud>()
                .HasOne(o => o.attractieOmTeOnderhouden)
                .WithMany(a => a.onderHouden);

            modelBuilder.Entity<OnderHoud>()
                .HasMany(o => o.medewerkers)
                .WithMany(m => m.onderhoudenTeDoen);

            modelBuilder.Entity<OnderHoud>()
                .HasMany(o => o.coordinatoren)
                .WithMany(m => m.onderhoudenTeCoordineren);

            modelBuilder.Entity<OnderHoud>()
                .OwnsOne(o => o.datumonderhoud);

            // Reservering
            modelBuilder.Entity<Reservering>()
                .HasOne(r => r.attractie)
                .WithMany(a => a.reserveringen)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservering>()
                .OwnsOne(r => r.datumReserveering);

        }
    }
}
