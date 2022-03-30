using System;
using System.Collections.Generic;

namespace VendorMachineTest.Domain.ViewModels
{
    public class SalesViewModel
    {
        public int Id { get; set; }
        public bool MaintenanceRequested { get; set; }
        public DateTime CreatedOn { get; set; }
        public MachineLanguageViewModel MachineLanguage { get; set; }
        public MachineCurrencyViewModel MachineCurrency { get; set; }
        public IEnumerable<MachineSlotsViewModel> MachineSlots { get; set; }
    }
}
