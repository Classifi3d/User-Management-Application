using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasIndex( x => x.Email).IsUnique();
            modelBuilder.Entity<Countries>().ToTable("Country");
            modelBuilder.Entity<Countries>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Countries>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<User>().HasMany(x => x.Countries)
                .WithMany(x => x.Users).UsingEntity<UserCountries>(
                "CountriesUser",
                z => z.HasOne<Countries>().WithMany().HasForeignKey("CountryId"),
                y => y.HasOne<User>().WithMany().HasForeignKey("UserId"),
                t => t.HasKey("UserId", "CountryId")
            );

            //modelBuilder.Entity<UserCountries>().HasKey(uc => new { uc.UserId, uc.CountryId });

        }

        public DbSet<User> Users{get; set;}
        public DbSet<UserCountries> UsersCountries { get; set; }
        public DbSet<Countries> Countries{get; set;} 
    }
}
