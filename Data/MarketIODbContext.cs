using MarketIO.MVC.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Order_Details> Order_Details { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order_Details>()
                        .HasKey(o => new { o.Order_Id, o.Product_Id });

            builder.Entity<IdentityRole>().HasData(
                  new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                  new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" },
                  new { Id = "3", Name = "Moderator", NormalizedName = "MODERATOR" }

           );
        }


    }
}
