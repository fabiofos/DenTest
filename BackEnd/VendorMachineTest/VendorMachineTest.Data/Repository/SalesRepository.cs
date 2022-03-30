using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.Repositories;

namespace VendorMachineTest.Data.Repository
{
    public class SalesRepository : RepositoryBase<Sales>, ISalesRepository
    {
        public SalesRepository(VendorMachineContext db) : base(db)
        {
        }
    }
}
