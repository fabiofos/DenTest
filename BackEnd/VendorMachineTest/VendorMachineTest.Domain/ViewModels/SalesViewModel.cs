using System;
using System.Collections.Generic;

namespace VendorMachineTest.Domain.ViewModels
{
    public class SalesViewModel
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductId { get; set; }
    }
}
