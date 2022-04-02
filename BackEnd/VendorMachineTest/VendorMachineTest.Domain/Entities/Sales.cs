using System;

namespace VendorMachineTest.Domain.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
