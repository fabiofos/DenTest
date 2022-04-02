using FluentValidation.Results;
using MediatR;
using VendorMachineTest.Domain.Interfaces.Commands;
using VendorMachineTest.Domain.Validations;
using System;

namespace VendorMachineTest.Domain.Commands
{
    public abstract class MachineCommand : IRequest<Result>, ICommand
    {
        public int Id { get; set; }
        public bool MaintenanceRequested { get; set; }
        public int MachineCurrencyId { get; set; }
        public int MachineLanguageId { get; set; }
        public DateTime CreatedOn { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            var validation = new MachineValidation();
            validation.ValidateCurrencyID();
            validation.ValidateLanguageID();
            validation.ValidateMaintenance();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}