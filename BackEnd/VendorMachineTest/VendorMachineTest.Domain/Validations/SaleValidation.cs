using FluentValidation;
using VendorMachineTest.Domain.Commands;

namespace VendorMachineTest.Domain.Validations
{
    public class SaleValidation : AbstractValidator<SaleCommand>
    {
        public void ValidateProductID()
        {
            RuleFor(p => p.ProductId)
                .GreaterThan(0).WithMessage("The Product ID must be greater than zero");
        }

        public void ValidatePrice()
        {
            RuleFor(p => p.ProductPrice)
                .GreaterThan(0).WithMessage("The Price must be greater than zero");
        }
    }
}