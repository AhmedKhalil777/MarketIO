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

            //seed categories
            builder.Entity<Categories>().HasData(new Categories { Cat_Id = 1, Cat_Name = "Laptops" });
            builder.Entity<Categories>().HasData(new Categories { Cat_Id = 2, Cat_Name = "TVS" });
            builder.Entity<Categories>().HasData(new Categories { Cat_Id = 3, Cat_Name = "Phones" });
            //seed brands
            builder.Entity<Brands>().HasData(new Brands { Brand_Id = 1, Brand_Name = "Hp" });
            builder.Entity<Brands>().HasData(new Brands { Brand_Id = 2, Brand_Name = "Toshiba" });
            builder.Entity<Brands>().HasData(new Brands { Brand_Id = 3, Brand_Name = "Apple" });

            //Seed products
            builder.Entity<Products>().HasData(new Products
            {
                Product_Id = 1,
                P_Name = "HP ProBook",
                Price = 152.95M,
                Description = "Awesome Laptop!",
                CategoryId = 1,
                BrandId = 1,
                Quantity=6,
                Image = "HP.PNG",
                InStock = true,
                IsProductOfTheWeek = true,
            });
            builder.Entity<Products>().HasData(new Products
            {
                Product_Id = 2,
                P_Name = "Mac Book",
                Price = 252.95M,
                Description = "Awesome Laptop!",
                CategoryId = 1,
                BrandId = 1,
                Quantity=6,
                Image = "Mac.JPG",
                InStock = true,
                IsProductOfTheWeek = true,
            });


        }


    }


    public class MarketIOContextFactory : IDesignTimeDbContextFactory<MarketIODbContext>
    {
        public MarketIODbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MarketIODbContext>();
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=MarketIO;Trusted_Connection=true;MultipleActiveResultSets=true");

            return new MarketIODbContext(optionsBuilder.Options);
        }
    }
}
