using VendorMachineTest.Data.Context;
using VendorMachineTest.Domain.Interfaces.Repositories;
using VendorMachineTest.Domain.Interfaces.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorMachineTest.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VendorMachineContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public UnitOfWork(VendorMachineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (Repositories.Keys.Contains(typeof(TEntity)))
            {
                return Repositories[typeof(TEntity)] as IRepositoryBase<TEntity>;
            }

            IRepositoryBase<TEntity> repo = new RepositoryBase<TEntity>(_dbContext);
            Repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
