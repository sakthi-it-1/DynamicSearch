using ClientSearch.Data.Entities;
using ClientSearch.Models.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClientSearch.Service.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<Client> WithSkipAndTake(this IQueryable<Client> query, int pageSize, int pageNumber)
        {
            query = query.Skip(pageNumber * pageSize).Take(pageSize);
            return query;   
        }

        public static IQueryable<Client> WithSearchIds(this IQueryable<Client> query, IEnumerable<Guid> clientIds)
        {
            if (clientIds is not null && clientIds.Any())
                query = query.Where(x => clientIds.Contains(x.ClientID));

            return query;
        }

        public static IQueryable<Client> WithDynamicFields(this IQueryable<Client> query, IEnumerable<Filter> filters)
        {
            if (filters is not null && filters.Any())
            {
                foreach (Filter filter in filters)
                {
                    query = query.FilterByProperty(filter.Field, filter.Value, filter.Operation);
                }
            }

            return query;
        }


        public static IQueryable<Client> AddClientNameWithEquals(this IQueryable<Client> query, string clientName, IEnumerable<Filter> filters)
        {
            if (!string.IsNullOrEmpty(clientName) && (!filters?.Where(x=>x.Value == "ClientName").Any() ?? true))
                query = query.Where(x => x.ClientName.Equals(clientName));
            return query;
        }

        public static IQueryable<Client> AddClientNameWithContains(this IQueryable<Client> query, string clientName, IEnumerable<Filter> filters)
        {
            if (!string.IsNullOrEmpty(clientName) && (!filters?.Where(x => x.Value == "ClientName").Any() ?? true))
                query=  query.Where(x => x.ClientName.Contains(clientName));
            return query;
        }

        public static IQueryable<Client> AddClientNameWithWildCard(this IQueryable<Client> query, string clientName, IEnumerable<Filter> filters)
        {
            if (!string.IsNullOrEmpty(clientName) && (!filters?.Where(x => x.Value == "ClientName").Any() ?? true))
                query= query.Where(x => x.ClientName.StartsWith(clientName));
            return query;
        }

        private static IQueryable<Client> FilterByProperty(this IQueryable<Client> query, string propertyName, string value, string oper)
        {
            var parameter = Expression.Parameter(typeof(Client), "c");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(value);

            var equals = Expression.Equal(property, constant);

            var lambda = Expression.Lambda<Func<Client, bool>>(equals, parameter);

            if (oper == "contains")
            {
                var methodInfo = typeof(List<string>).GetMethod("Contains", new Type[] { typeof(string) }); // Contains Method
                Expression body = Expression.Call(constant, methodInfo, property);
                lambda = Expression.Lambda<Func<Client, bool>>(body, parameter);
            }

            query = query.Where(lambda);

            return query;
        }
    }
}
