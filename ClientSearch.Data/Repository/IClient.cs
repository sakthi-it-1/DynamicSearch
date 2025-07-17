using ClientSearch.Data.Entities;
using System.Linq.Expressions;

namespace ClientSearch.Data.Repository
{
    public interface IClient<TEntity>  where TEntity : class
    {
        Task<IEnumerable<TEntity>> SearchClientAsync<T>(Expression<Func<TEntity, bool>> filter);
    }
}
