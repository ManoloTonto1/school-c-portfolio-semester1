namespace apiApp.models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : IdentityDbContext<User>
{
    public DatabaseContext() : base()
    {
    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<User> users { get; set; }
    public DbSet<Attraction> attractions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=sqlitedb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => x.UserId);
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => x.UserId);

        modelBuilder.Entity<Attraction>().HasKey(a => a.ID);

        modelBuilder.Entity<User>()
            .HasMany(u => u.likedAttractions)
            .WithMany(a => a.userLikes)
            .UsingEntity("likes");
    }
}