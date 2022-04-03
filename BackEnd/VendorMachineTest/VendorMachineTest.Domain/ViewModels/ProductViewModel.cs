using System;

namespace VendorMachineTest.Domain.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProductStockViewModel ProductStock { get; set; }
        public int ProductStockId { get; set; }
    }
}
