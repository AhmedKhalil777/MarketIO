using MarketIO.MVC.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Data
{
    public class MarketIODbContext : IdentityDbContext<Customers>
    {

        public MarketIODbContext(DbContextOptions<MarketIODbContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ShoppingCartItem>()
                        .HasKey(o => new { o.ShoppingCartId, o.Product_Id });

            builder.Entity<IdentityRole>().HasData(
                  new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                  new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" },
                  new { Id = "3", Name = "Moderator", NormalizedName = "MODERATOR" }

           );
        }


    }


    public class MarketIOContextFactory : IDesignTimeDbContextFactory<MarketIODbContext>
    {
        public MarketIODbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MarketIODbContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-KVVKP5M\\AHMED;database=MarketIOFirst;Trusted_Connection=true;MultipleActiveResultSets=true");

            return new MarketIODbContext(optionsBuilder.Options);
        }
    }
}
