using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VendorMachineTest.Tests.Infrastructure
{
    public class InMemoryInitializer
    {
        public static void Initialize(VendorMachineContext sqlDbContext)
        {
            if (sqlDbContext.Product.Any())
                return;

            AddProducts(sqlDbContext);
        }

        public static async void AddProducts(VendorMachineContext context)
        {
            var products = new List<Product> { 
              new Product { Name = "Iphone 13", CreatedOn = DateTime.Now, Description = "Apple Iphone 13", Price = 1100 },
              new Product { Name = "IPad Pro", CreatedOn = DateTime.Now, Description = "Apple Ipad Pro 13 inch", Price = 1250 },
              new Product { Name = "HP deskjet", CreatedOn = DateTime.Now, Description = "HP printer", Price = 50 },
              new Product { Name = "Dell 6550", CreatedOn = DateTime.Now, Description = "Dell Latitude gaming laptop", Price = 650 },
            };

            foreach (var prod in products)
            {
                context.Add(prod);
                await context.SaveChangesAsync();
            }
        }
    }
}
