using System;

namespace VendorMachineTest.Domain.Entities
{
    public class ProductStock
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
