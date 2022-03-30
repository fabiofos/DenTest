using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.Repositories;

namespace VendorMachineTest.Data.Repository
{
    public class MachineRepository : RepositoryBase<Machine>, IMachineRepository
    {
        public MachineRepository(VendorMachineContext db) : base(db)
        {
        }
    }
}
