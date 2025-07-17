using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace ClientSearch.Data.Repository
{
    public class ClientRepo<TEntity> : IClient<TEntity> where TEntity : class
    {
        private DbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        public ClientRepo(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> SearchClientAsync<T>(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
    }
}
