using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using SineadK.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SineadK.Data
{
    public class SineadSeeder
    {
        private readonly SineadContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public SineadSeeder(SineadContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if(!_ctx.Products.Any())
            {
                //need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/products.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "1234",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };
                _ctx.Orders.Add(order);
                _ctx.SaveChanges();

            }

            
        }
    }
}
