using ClientSearch.Data.Entities;
using System.Linq.Expressions;

namespace ClientSearch.Data.Repository
{
    public interface IClient<TEntity>  where TEntity : class
    {
        IQueryable<TEntity> GetBaseQuery();
        Task<IEnumerable<TEntity>> SearchClientAsync<TEntity>(IQueryable<TEntity> query);
    }
}
