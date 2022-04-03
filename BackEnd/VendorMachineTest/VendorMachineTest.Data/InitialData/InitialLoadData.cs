using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VendorMachineTest.Domain.Entities;

namespace VendorMachineTest.Data.InitialData
{
    [ExcludeFromCodeCoverage]
    public static class InitialLoadData
    {
        public async static void Seed(ModelBuilder modelBuilder)
        {
            DateTime createdOn = DateTime.UtcNow;
            #region MachineLanguage
            modelBuilder.Entity<MachineLanguage>().HasData(
             new List<MachineLanguage>
             {
                 new MachineLanguage
                 {
                     Id = 1,
                     Language = "EN",
                     CreatedOn = createdOn,
                 },
                 new MachineLanguage
                 {
                     Id = 2,
                     Language = "DE",
                     CreatedOn = createdOn,
                 },
                 new MachineLanguage
                 {
                     Id = 3,
                     Language = "FR",
                     CreatedOn = createdOn,
                 }
             }
            );
            #endregion MachineLanguage

            #region MachineCurrency
            modelBuilder.Entity<MachineCurrency>().HasData(
             new List<MachineCurrency>
             {
                    new MachineCurrency
                    {
                        Id = 1,
                        Currency = "EUR",
                        CreatedOn = createdOn
                    },
                    new MachineCurrency
                    {
                        Id = 2,
                        Currency = "USD",
                        CreatedOn = createdOn
                    }
             }
            );
            #endregion MachineCurrency

            #region ProductStock
            modelBuilder.Entity<ProductStock>().HasData(
                new List<ProductStock>
                {
                    new ProductStock
                    {
                        Id = 1,
                        Quantity = 8,
                        CreatedOn = createdOn
                    },
                    new ProductStock
                    {
                        Id = 2,
                        Quantity = 12,
                        CreatedOn = createdOn
                    },
                    new ProductStock
                    {
                        Id = 3,
                        Quantity = 0,
                        CreatedOn = createdOn
                    },
                }
            );
            #endregion ProductStock

            #region Product
            modelBuilder.Entity<Product>().HasData(
             new List<Product>
             {
                    new Product
                    {
                        Id = 1,
                        Name = "COLA",
                        Description = "Coca Cola",
                        Price = new decimal(1.00),
                        CreatedOn = createdOn,
                        ProductStockId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Chips",
                        Description = "Chips",
                        Price = new decimal(0.50),
                        CreatedOn = createdOn,
                        ProductStockId = 2
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Candy",
                        Description = "Candy",
                        Price = new decimal(1.65),
                        CreatedOn = createdOn,
                        ProductStockId = 3
                    },
             }
            );
            #endregion Product

            #region MachineSlots
            modelBuilder.Entity<MachineSlots>().HasData(
             new List<MachineSlots>
             {
                    new MachineSlots
                    {
                        Id = 1,
                        ProductId = 1,
                        MachineId = 1,
                        SlotName = "Slot 1",
                        CreatedOn = createdOn
                    },
                    new MachineSlots
                    {
                        Id = 2,
                        ProductId = 2,
                        MachineId = 1,
                        SlotName = "Slot 2",
                        CreatedOn = createdOn
                    },
                    new MachineSlots
                    {
                        Id = 3,
                        ProductId = 3,
                        MachineId = 1,
                        SlotName = "Slot 3",
                        CreatedOn = createdOn
                    },
                    new MachineSlots
                    {
                        Id = 4,
                        ProductId = null,
                        MachineId = 1,
                        SlotName = "Slot 4",
                        CreatedOn = createdOn
                    },
                    new MachineSlots
                    {
                        Id = 5,
                        ProductId = null,
                        MachineId = 1,
                        SlotName = "Slot 5",
                        CreatedOn = createdOn
                    }
             }
            );
            #endregion MachineSlots

            #region Machine
            modelBuilder.Entity<Machine>().HasData(
             new Machine
             {
                 Id = 1,
                 MaintenanceRequested = false,
                 MachineCurrencyId = 1,
                 MachineLanguageId = 1,
                 CreatedOn = createdOn
             });
            #endregion Machine
        }
   }
}