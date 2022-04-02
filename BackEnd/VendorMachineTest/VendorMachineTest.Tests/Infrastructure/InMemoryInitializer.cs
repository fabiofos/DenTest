using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VendorMachineTest.Tests.Infrastructure
{
    public class InMemoryInitializer
    {
        public static async void Initialize(VendorMachineContext sqlDbContext)
        {
            AddCurrencyMachine(sqlDbContext);

            AddLanguageMachine(sqlDbContext);

            AddMachine(sqlDbContext);

            AddProducts(sqlDbContext);

            AddSlotsMachine(sqlDbContext);

            AddProductStocks(sqlDbContext);

            AddProductSales(sqlDbContext);
        }

        public static async void AddCurrencyMachine(VendorMachineContext context)
        {
            if (context.MachineCurrency.Any())
                return;

            var machineCurrencies =
                  new List<MachineCurrency>
             {
                    new MachineCurrency
                    {
                        Id = 1,
                        Currency = "EUR",
                        CreatedOn = DateTime.UtcNow
                    },
                    new MachineCurrency
                    {
                        Id = 2,
                        Currency = "USD",
                        CreatedOn = DateTime.UtcNow
                    }
             };

            foreach (var machineccy in machineCurrencies)
            {
                context.Add(machineccy);
                await context.SaveChangesAsync();
            }
        }
        public static async void AddLanguageMachine(VendorMachineContext context)
        {
            if (context.MachineLanguage.Any())
                return;

            var machineLanguages =
            new List<MachineLanguage>
             {
                 new MachineLanguage
                 {
                     Id = 1,
                     Language = "EN",
                     CreatedOn = DateTime.UtcNow,
                 },
                 new MachineLanguage
                 {
                     Id = 2,
                     Language = "DE",
                     CreatedOn = DateTime.UtcNow,
                 },
                 new MachineLanguage
                 {
                     Id = 3,
                     Language = "FR",
                     CreatedOn = DateTime.UtcNow,
                 }
             };

            foreach (var machineLanguage in machineLanguages)
            {
                context.Add(machineLanguage);
                await context.SaveChangesAsync();
            }
        }
        public static async void AddSlotsMachine(VendorMachineContext context)
        {
            if (context.MachineSlots.Any())
                return;

            var machineSlots =
            new List<MachineSlots>
             {
                    new MachineSlots
                    {
                        Id = 1,
                        ProductId = 1,
                        MachineId = 1,
                        SlotName = "Slot 1",
                        CreatedOn = DateTime.UtcNow
                    },
                    new MachineSlots
                    {
                        Id = 2,
                        ProductId = 2,
                        MachineId = 1,
                        SlotName = "Slot 2",
                        CreatedOn = DateTime.UtcNow
                    },
                    new MachineSlots
                    {
                        Id = 3,
                        ProductId = 3,
                        MachineId = 1,
                        SlotName = "Slot 3",
                        CreatedOn = DateTime.UtcNow
                    },
                    new MachineSlots
                    {
                        Id = 4,
                        ProductId = null,
                        MachineId = 1,
                        SlotName = "Slot 4",
                        CreatedOn = DateTime.UtcNow
                    },
                    new MachineSlots
                    {
                        Id = 5,
                        ProductId = null,
                        MachineId = 1,
                        SlotName = "Slot 5",
                        CreatedOn = DateTime.UtcNow
                    }
             };

            foreach (var machineSlot in machineSlots)
            {
                context.Add(machineSlot);
                await context.SaveChangesAsync();
            }
        }
        public static async void AddProducts(VendorMachineContext context)
        {
            if (context.Product.Any())
                return;

            var products =
                new List<Product>
             {
                    new Product
                    {
                        Id = 1,
                        Name = "COLA",
                        Description = "Coca Cola",
                        Price = new decimal(1.00),
                        CreatedOn = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Chips",
                        Description = "Chips",
                        Price = new decimal(0.50),
                        CreatedOn = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Candy",
                        Description = "Candy",
                        Price = new decimal(1.65),
                        CreatedOn = DateTime.UtcNow
                    },
             };

            foreach (var product in products)
            {
                context.Add(product);
                await context.SaveChangesAsync();
            }
        }
        public static async void AddProductStocks(VendorMachineContext context)
        {
            if (context.ProductStock.Any())
                return;

            var productStocks =
            new List<ProductStock>
                {
                    new ProductStock
                    {
                        Id = 1,
                        ProductId = 1,
                        Quantidade = 8,
                        CreatedOn = DateTime.UtcNow
                    },
                    new ProductStock
                    {
                        Id = 2,
                        ProductId = 2,
                        Quantidade = 12,
                        CreatedOn =  DateTime.UtcNow
                    },
                    new ProductStock
                    {
                        Id = 3,
                        ProductId = 3,
                        Quantidade = 0,
                        CreatedOn =  DateTime.UtcNow
                    },
                };

            foreach (var ps in productStocks)
            {
                context.Add(ps);
                await context.SaveChangesAsync();
            }
        }
        public static async void AddMachine(VendorMachineContext context)
        {
            if (context.Machine.Any())
                return;

            var machine = new Machine { Id = 1, CreatedOn = DateTime.UtcNow, MachineCurrencyId = 1, MachineLanguageId = 1, MaintenanceRequested = false };

            context.Add(machine);

            await context.SaveChangesAsync();
        }
        public static async void AddProductSales(VendorMachineContext context)
        {
            if (context.Sales.Any())
                return;

            var sales =
            new List<Sales>
                {
                    new Sales
                    {
                        Id = 1,
                        ProductId = 1,
                        ProductPrice =  new decimal(1.00),
                        CreatedOn = DateTime.UtcNow
                    },
                    new Sales
                    {
                        Id = 2,
                        ProductId = 2,
                        ProductPrice =  new decimal(0.50),
                        CreatedOn = DateTime.UtcNow
                    },
                    new Sales
                    {
                        Id = 3,
                        ProductId = 3,
                        ProductPrice =  new decimal(1.65),
                        CreatedOn = DateTime.UtcNow
                    },
                };

            foreach (var sale in sales)
            {
                context.Add(sale);
                await context.SaveChangesAsync();
            }
        }
    }
}
