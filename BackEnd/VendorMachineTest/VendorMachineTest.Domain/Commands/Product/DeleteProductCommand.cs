using VendorMachineTest.Domain.Validations;

namespace VendorMachineTest.Domain.Commands.Product
{
    public class DeleteProductCommand : ProductCommand
    {
        public DeleteProductCommand(int id) =>
          Id = id;

        public override bool IsValid() //overriding the validation just to take in consideration the Id
        {
            var validation = new ProductValidation();
            validation.ValidateID();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
