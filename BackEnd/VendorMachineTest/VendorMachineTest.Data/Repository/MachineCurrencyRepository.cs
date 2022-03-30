using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.Repositories;

namespace VendorMachineTest.Data.Repository
{
    public class MachineCurrencyRepository : RepositoryBase<MachineCurrency>, IMachineCurrencyRepository
    {
        public MachineCurrencyRepository(VendorMachineContext db) : base(db)
        {
        }
    }
}
