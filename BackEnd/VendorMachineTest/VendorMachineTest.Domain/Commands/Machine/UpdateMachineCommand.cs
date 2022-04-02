using VendorMachineTest.Domain.Validations;
using System;

namespace VendorMachineTest.Domain.Commands.Product
{
    public class UpdateMachineCommand : SaleCommand
    {
        public UpdateMachineCommand()
        {
        }

        public int Id { get; set; }
        public bool MaintenanceRequested { get; set; }
        public int MachineCurrencyId { get; set; }
        public int MachineLanguageId { get; set; }
        public DateTime CreatedOn { get; set; }

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
            var validation = new SaleValidation();
            validation.ValidateProductID();
            validation.ValidatePrice();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
