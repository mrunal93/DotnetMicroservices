using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;


//Command to run   add-migration  __________  Update-database ________  add-migration seedCouponTables

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }

        public DbSet<Coupon> Coupones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon {
                
                CouponId = 1,
                CouponCode =  "Mrunal",
                DiscountAmount = 20,
                MinAmount = 40
                
            });
        }
    }
}
