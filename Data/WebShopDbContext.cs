using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Data.DbModels;

namespace WebShop.Data
{
    public class WebShopDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) :
            base(options)
        {
        }

        public override DbSet<User> Users { get; set; }
        public DbSet<Pair> Items { get; init; }
        public DbSet<ShopingCart> Carts { get; init; }
        public DbSet<Order> Orders { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c => c.Orders).WithOne(c => c.User);
            modelBuilder.Entity<Order>().HasMany(c => c.Items);
            modelBuilder.Entity<ShopingCart>().HasMany(c => c.Items);
            modelBuilder.Entity<ShopingCart>().HasOne(c => c.Owner);

            base.OnModelCreating(modelBuilder);
        }
    }
}
