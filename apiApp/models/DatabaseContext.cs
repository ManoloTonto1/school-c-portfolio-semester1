namespace apiApp.models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{

    public DbSet<User> users { get; set; }
    public DbSet<Attraction> attractions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=sqlitedb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.ID);

        modelBuilder.Entity<Attraction>().HasKey(a => a.ID);

        modelBuilder.Entity<User>()
            .HasMany(u => u.likedAttractions)
            .WithMany(a => a.userLikes)
            .UsingEntity("likes");
    }
}