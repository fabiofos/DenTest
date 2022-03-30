using System;

namespace VendorMachineTest.Domain.Commands.Product
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand()
        {
        }

        public UpdateProductCommand(string name, string description, decimal price, int quantity, DateTime createdOn)
        {
            Description = description;
            Name = name;
            Price = price;
            Quantity = quantity;
            CreatedOn = createdOn;
        }

    }
}
