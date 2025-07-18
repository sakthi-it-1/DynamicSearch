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

        public IQueryable<TEntity> GetBaseQuery()
        {
            return _dbContext.Set<TEntity>().AsQueryable<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> SearchClientAsync<TEntity>(IQueryable<TEntity> query)
        {
            return await query.ToListAsync();
        }
    }
}
