using FluentValidation.Results;
using MediatR;
using VendorMachineTest.Domain.Interfaces.Commands;
using VendorMachineTest.Domain.Validations;
using System;

namespace VendorMachineTest.Domain.Commands
{
    public abstract class SaleCommand : IRequest<Result>, ICommand
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            var validation = new SaleValidation();
            validation.ValidateProductID();
            validation.ValidatePrice();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}