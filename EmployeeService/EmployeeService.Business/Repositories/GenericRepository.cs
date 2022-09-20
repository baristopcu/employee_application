using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EmployeeService.Data.Context;
using EmployeeService.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.BusinessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly EmployeeContext _employeeContext;

        public GenericRepository(EmployeeContext context)
        {
            this._employeeContext = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _employeeContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _employeeContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _employeeContext.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _employeeContext.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return _employeeContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _employeeContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _employeeContext.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _employeeContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }
}

