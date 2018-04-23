using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using TinyShoppingCart.Server.Domain.Entities;

namespace TinyShoppingCart.Server.DataAccess.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyInclude<T>(this IQueryable<T> query, IQueryObject queryObj) where T: class
        {
            if(string.IsNullOrWhiteSpace(queryObj.IncludeProperties))
            {
                return query;
            }

            foreach (var includeProperty in queryObj.IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include<T>(includeProperty);
            }

            return query;
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if(queryObj == null)
            {
                return query;
            }

            if(!string.IsNullOrWhiteSpace(queryObj.OrderBy) && columnsMap.ContainsKey(queryObj.OrderBy.ToLower()))
            {
                if(queryObj.IsOrderAscending)
                {
                    return query.OrderBy(columnsMap[queryObj.OrderBy.ToLower()]);
                }

                return query.OrderByDescending(columnsMap[queryObj.OrderBy.ToLower()]);
            }

            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if(queryObj == null)
            {
                return query;
            }

            if(queryObj.Start < 0)
            {
                queryObj.Start = 0;
            }

            if(queryObj.PageSize <= 0)
            {
                queryObj.PageSize = 25;
            }

            return query.Skip(queryObj.Start).Take(queryObj.PageSize);
        }
    }
}