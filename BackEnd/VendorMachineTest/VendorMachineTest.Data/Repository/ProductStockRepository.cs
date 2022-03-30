using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.Repositories;

namespace VendorMachineTest.Data.Repository
{
    public class ProductStockRepository : RepositoryBase<ProductStock>, IProductStockRepository
    {
        public ProductStockRepository(VendorMachineContext db) : base(db)
        {
        }
    }
}
