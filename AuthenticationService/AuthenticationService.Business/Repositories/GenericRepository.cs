using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AuthenticationService.Business.Interfaces;
using AuthenticationService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Business.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AuthenticationContext _authenticationContext;

        public GenericRepository(AuthenticationContext context)
        {
            this._authenticationContext = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _authenticationContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _authenticationContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _authenticationContext.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _authenticationContext.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return _authenticationContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _authenticationContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _authenticationContext.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _authenticationContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }
}

