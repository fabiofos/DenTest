using System;
using System.Collections.Generic;

namespace VendorMachineTest.Domain.ViewModels
{
    public class MachineViewModel
    {
        public int Id { get; set; }
        public bool MaintenanceRequested { get; set; }
        public DateTime CreatedOn { get; set; }
        public MachineLanguageViewModel MachineLanguage { get; set; }
        public MachineCurrencyViewModel MachineCurrency { get; set; }
        public int MachineCurrencyId { get; set; }
        public int MachineLanguageId { get; set; }
    }
}
