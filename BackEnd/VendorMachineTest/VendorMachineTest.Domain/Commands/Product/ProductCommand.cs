using FluentValidation.Results;
using MediatR;
using VendorMachineTest.Domain.Interfaces.Commands;
using VendorMachineTest.Domain.Validations;
using VendorMachineTest.Domain.ViewModels;
using System;

namespace VendorMachineTest.Domain.Commands
{
    public abstract class ProductCommand : IRequest<Result>, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            var validation = new ProductValidation();
            validation.ValidateID();
            validation.ValidateDescription();
            validation.ValidateName();
            validation.ValidateQuantity();
            validation.ValidatePrice();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}