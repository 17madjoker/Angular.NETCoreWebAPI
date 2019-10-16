using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AngularCoreApp.Models;

namespace AngularCoreApp.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Ordering<T>(
            this IQueryable<T> query,
            IQuery queryByClient,
            Dictionary<string, Expression<Func<T, object>>> sortMap)
        {
            if (String.IsNullOrWhiteSpace(queryByClient.SortBy) || !sortMap.ContainsKey(queryByClient.SortBy))
                return query;
            
            if (queryByClient.IsSortAsc)
                query = query.OrderBy(sortMap[queryByClient.SortBy]);
            else 
                query = query.OrderByDescending(sortMap[queryByClient.SortBy]);

            return query;
        }

        public static IQueryable<T> Paging<T>(this IQueryable<T> query, IQuery queryByClient)
        {
            if (queryByClient.Page <= 0)
                queryByClient.Page = 1;    
            
            if (queryByClient.PageSize <= 0)
                queryByClient.PageSize = 3;    
                
            query = query.Skip((queryByClient.Page - 1) * queryByClient.PageSize).Take(queryByClient.PageSize);

            return query;
        }
    }
}