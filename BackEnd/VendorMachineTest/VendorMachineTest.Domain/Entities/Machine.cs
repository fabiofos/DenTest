using System;
using System.Collections.Generic;

namespace VendorMachineTest.Domain.Entities
{
    public class Machine
    {
        public int Id { get; set; }
        public bool MaintenanceRequested { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual MachineLanguage MachineLanguage { get; set; }
        public virtual MachineCurrency MachineCurrency { get; set; }
        public int MachineCurrencyId { get; set; }
        public int MachineLanguageId { get; set; }
    }
}
