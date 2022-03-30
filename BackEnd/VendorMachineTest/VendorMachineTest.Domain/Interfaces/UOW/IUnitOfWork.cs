using VendorMachineTest.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace VendorMachineTest.Domain.Interfaces.UOW
{
    public interface IUnitOfWork
    {
        IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> Commit();

        void Rollback();
    }
}
