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
    public class MarketIODbContext : IdentityDbContext<IdentityUser>
    {
        public MarketIODbContext(DbContextOptions<MarketIODbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    

            builder.Entity<IdentityRole>().HasData(
                  new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                  new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" },
                  new { Id = "3", Name = "Moderator", NormalizedName = "MODERATOR" }

           );
        }


    }
}
