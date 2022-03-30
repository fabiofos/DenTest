using VendorMachineTest.Domain.Validations;
using System;

namespace VendorMachineTest.Domain.Commands.Product
{
    public class CreateProductCommand : ProductCommand
    {
        public CreateProductCommand()
        {
        }

        public CreateProductCommand(int id, string name, string description, decimal price, int quantity, DateTime createdOn)
        {
            Id = id;
            Description = description;
            Name = name;
            Price = price;
            Quantity = quantity;
            CreatedOn = createdOn;
        }

        public override bool IsValid() //overriding the validation just to take in consideration the Id
        {
            var validation = new ProductValidation();
            validation.ValidateDescription();
            validation.ValidateName();
            validation.ValidateQuantity();
            validation.ValidatePrice();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
