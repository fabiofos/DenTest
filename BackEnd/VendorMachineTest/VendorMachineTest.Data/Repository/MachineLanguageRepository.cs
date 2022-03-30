using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.Repositories;

namespace VendorMachineTest.Data.Repository
{
    public class MachineLanguageRepository : RepositoryBase<MachineLanguage>, IMachineLanguageRepository
    {
        public MachineLanguageRepository(VendorMachineContext db) : base(db)
        {
        }
    }
}
