using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.Repositories;

namespace VendorMachineTest.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(VendorMachineContext db) : base(db)
        {
        }
    }
}
