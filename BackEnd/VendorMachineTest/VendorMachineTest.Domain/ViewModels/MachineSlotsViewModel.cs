using System;

namespace VendorMachineTest.Domain.ViewModels
{
    public class MachineSlotsViewModel
    {
        public int Id { get; set; }
        public string SlotName { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProductViewModel Product { get; set; }
        public MachineViewModel Machine { get; set; }
        public int? ProductId { get; set; }
        public int MachineId { get; set; }
    }
}
