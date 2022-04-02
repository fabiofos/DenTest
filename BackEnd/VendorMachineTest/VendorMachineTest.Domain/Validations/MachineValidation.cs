using FluentValidation;
using VendorMachineTest.Domain.Commands;

namespace VendorMachineTest.Domain.Validations
{
    public class MachineValidation : AbstractValidator<MachineCommand>
    {
        public void ValidateCurrencyID()
        {
            RuleFor(p => p.MachineCurrencyId)
                .GreaterThan(0).WithMessage("The Machine must have at least one currency");
        }

        public void ValidateLanguageID()
        {
            RuleFor(p => p.MachineLanguageId)
                .GreaterThan(0).WithMessage("The Machine must have at least one language");
        }

        public void ValidateMaintenance()
        {
            RuleFor(p => p.MaintenanceRequested)
                .NotNull().WithMessage("The Maintenance field must be present");
        }
    }
}