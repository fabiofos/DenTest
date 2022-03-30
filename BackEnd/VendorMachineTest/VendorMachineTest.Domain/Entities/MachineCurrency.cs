using System;

namespace VendorMachineTest.Domain.Entities
{
    public class MachineCurrency
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
