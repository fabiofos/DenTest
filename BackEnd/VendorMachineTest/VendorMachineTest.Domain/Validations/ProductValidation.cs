using FluentValidation;
using VendorMachineTest.Domain.Commands;

namespace VendorMachineTest.Domain.Validations
{
    public class ProductValidation : AbstractValidator<ProductCommand>
    {
        public void ValidateID()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("The ID must be greater than zero");
        }

        public void ValidateDescription()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("The Description cannot be empty")
                .MaximumLength(150).WithMessage("The Description must be a maximum of 150 characters");
        }

        public void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The Name cannot be empty")
                .MaximumLength(150).WithMessage("The Name must be a maximum of 150 characters");
        }

        public void ValidateQuantity()
        {
            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("The Quantity must be greater than zero");
        }

        public void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("The Price must be greater than zero");
        }
    }
}