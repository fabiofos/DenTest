using System;

namespace VendorMachineTest.Domain.ViewModels
{
    public class ProductStockViewModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }
    }
}
