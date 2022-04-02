using VendorMachineTest.Domain.Validations;
using System;

namespace VendorMachineTest.Domain.Commands.Product
{
    public class CreateSaleCommand : SaleCommand
    {
        public CreateSaleCommand()
        {
        }

        public CreateSaleCommand(int productId, decimal productPrice, DateTime createdOn)
        {
            ProductId = productId;
            ProductPrice = productPrice;
            CreatedOn = createdOn;
        }

        public override bool IsValid() //overriding the validation just to take in consideration the Id
        {
            var validation = new SaleValidation();
            validation.ValidateProductID();
            validation.ValidatePrice();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
