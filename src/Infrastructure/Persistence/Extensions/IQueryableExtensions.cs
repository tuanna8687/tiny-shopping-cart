using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using TinyShoppingCart.Domain.Entities;

namespace TinyShoppingCart.Infrastructure.Persistence.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyTrackingInclude<T>(this IQueryable<T> query, IQueryInclude queryObj) where T: class
        {
            query = ApplyTracking(query, queryObj);

            query = ApplyInclude(query, queryObj);

            return query;
        }

        public static IQueryable<T> ApplyInclude<T>(this IQueryable<T> query, IQueryInclude queryObj) where T: class
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

        public static IQueryable<T> ApplyOrdering<T, TOrderProperty>(this IQueryable<T> query, IQueryOrder<T, TOrderProperty> queryObj)
        {
            if(queryObj == null)
            {
                return query;
            }

            if(queryObj.OrderBy == null)
            {
                return query;
            }

            if(queryObj.IsOrderAscending)
            {
                return query.OrderBy(queryObj.OrderBy);
            }

            return query.OrderByDescending(queryObj.OrderBy);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryPaging queryObj)
        {
            if(queryObj == null)
            {
                return query;
            }

            if(queryObj.PageIndex < 0)
            {
                queryObj.PageIndex = 0;
            }

            if(queryObj.PageSize <= 0)
            {
                queryObj.PageSize = 25;
            }

            return query.Skip(queryObj.PageIndex * queryObj.PageSize).Take(queryObj.PageSize);
        }

        public static IQueryable<T> ApplyTracking<T>(this IQueryable<T> query, IQueryInclude queryObj) where T: class
        {
            if(queryObj.IsTracking)
            {
                return query;
            }

            return query.AsNoTracking<T>();
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate) where T: class
        {
            if(predicate == null)
            {
                return query;
            }

            return query.Where(predicate);
        }
    }
}