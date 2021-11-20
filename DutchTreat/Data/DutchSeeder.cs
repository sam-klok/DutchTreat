using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _ctx;
        private readonly IWebHostEnvironment _env;

        public DutchSeeder(DutchContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data/art.json");
                var json = System.IO.File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                _ctx.Products.AddRange(products);


                var order = new Order()
                {
                    Id = 2,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "10000",
                    Items = new List<OrderItem>
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };


                _ctx.SaveChanges();
            }
        }
    }
}
