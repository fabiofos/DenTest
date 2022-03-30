using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VendorMachineTest.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity Obj);

        Task<IEnumerable<TEntity>> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetById(int Id);

        Task<IEnumerable<TEntity>> GetAll();

        Task Update(TEntity Obj);

        Task Remove(TEntity Obj);

        Task<IEnumerable<TEntity>> GetPagedRecords(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderBy, int pageNo, int pageSize);
    }
}
