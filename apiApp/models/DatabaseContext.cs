namespace apiApp.models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{

    public DbSet<User> users { get; set; }
    public DbSet<Guest> guests { get; set; }
    public DbSet<Attraction> attractions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite(@"Server=localhost\MSSQLSERVER02;Database=ApiApp;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.ID);
        
        modelBuilder.Entity<Attraction>().HasKey(u => u.ID);

        modelBuilder.Entity<Guest>()
            .HasMany(u => u.likedAttractions)
            .WithMany(a => a.userLikes)
            .UsingEntity("likes");
    }
}