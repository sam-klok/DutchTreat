using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DutchTreat.Data
{
    public class DutchContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DutchContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public IConfiguration _config { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlServer(_config.GetConnectionString("PureWebApiDB"));

            //optionsBuilder.UseSqlServer(_config.GetConnectionString("DutchTreatDB"));  // with this I been ablle to create new DB 
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"
                });
        }



    }
}
