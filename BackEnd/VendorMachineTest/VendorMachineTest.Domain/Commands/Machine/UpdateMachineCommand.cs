using VendorMachineTest.Domain.Validations;
using System;

namespace VendorMachineTest.Domain.Commands.Product
{
    public class UpdateMachineCommand : MachineCommand
    {
        public UpdateMachineCommand()
        {
        }
        public UpdateMachineCommand(int id, bool maintenanceRequested, int machineCurrencyId, int machineLanguageId, DateTime createdOn)
        {
            Id = id;
            MaintenanceRequested = maintenanceRequested;
            MachineLanguageId = machineLanguageId;
            MachineCurrencyId = machineCurrencyId;
            CreatedOn = createdOn;
        }

        public override bool IsValid() //overriding the validation just to take in consideration the Id
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
