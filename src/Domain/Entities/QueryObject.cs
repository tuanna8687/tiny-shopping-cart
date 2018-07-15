using System;
using System.Linq.Expressions;

namespace TinyShoppingCart.Domain.Entities
{
    public class QueryObject<TEntity, TOrderProperty> : IQueryObject<TEntity, TOrderProperty>
    {
        public string IncludeProperties { get; set; }
        public Expression<Func<TEntity, TOrderProperty>> OrderBy { get;set;}
        public bool IsOrderAscending { get;set; }
        public int PageSize { get;set; }
        public bool IsTracking { get;set; }
        public int PageIndex { get;set; }
    }
}