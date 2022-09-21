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

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _authenticationContext.Set<TEntity>().Where(predicate).AsQueryable();


            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return await query.ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _authenticationContext.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await _authenticationContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _authenticationContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _authenticationContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _authenticationContext.Set<TEntity>().Where(predicate).AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }


            return await query.SingleOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _authenticationContext.Set<TEntity>().Where(predicate).AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }


            return await query.FirstOrDefaultAsync();
        }
        public void Update(TEntity tEntity)
        {
            _authenticationContext.Entry(tEntity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await _authenticationContext.SaveChangesAsync();
        }
    }
}

