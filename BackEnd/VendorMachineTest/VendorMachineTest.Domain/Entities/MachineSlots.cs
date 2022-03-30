using System;

namespace VendorMachineTest.Domain.Entities
{
    public class MachineSlots
    {
        public int Id { get; set; }
        public string SlotName { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Product Product { get; set; }
        public virtual Machine Machine { get; set; }
        public int? ProductId { get; set; }
        public int MachineId { get; set; }
    }
}
