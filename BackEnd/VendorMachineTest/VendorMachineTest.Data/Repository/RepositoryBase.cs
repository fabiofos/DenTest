using Microsoft.EntityFrameworkCore;
using VendorMachineTest.Data.Context;
using VendorMachineTest.Data.UOW;
using VendorMachineTest.Domain.Interfaces.Repositories;
using VendorMachineTest.Domain.Interfaces.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VendorMachineTest.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly VendorMachineContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(VendorMachineContext db)
        {
            _db = db;
            _unitOfWork = new UnitOfWork(db);
        }

        public virtual async Task Add(TEntity Obj)
        {
            _db.Set<TEntity>().Add(Obj);
            await _unitOfWork.Commit();
        }

        public virtual async Task<IEnumerable<TEntity>> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _db.Set<TEntity>().AsQueryable().AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
           return await query.Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int Id)
        {
           return await _db.Set<TEntity>().FindAsync(Id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
           return await _db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task Update(TEntity Obj)
        {
            _db.Set<TEntity>().Attach(Obj);
            _db.Entry(Obj).State = EntityState.Modified;
            await _unitOfWork.Commit();
        }

        public virtual async Task Remove(TEntity Obj)
        {
            _db.Set<TEntity>().Remove(Obj);
            await _unitOfWork.Commit();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPagedRecords(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderBy, int pageNo, int pageSize)
        {
           return await (_db.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip((pageNo - 1) * pageSize).Take(pageSize)).ToListAsync();
        }
    }
}
