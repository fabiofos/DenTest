using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.Repositories;

namespace VendorMachineTest.Data.Repository
{
    public class MachineSlotsRepository : RepositoryBase<MachineSlots>, IMachineSlotsRepository
    {
        public MachineSlotsRepository(VendorMachineContext db) : base(db)
        {
        }
    }
}
