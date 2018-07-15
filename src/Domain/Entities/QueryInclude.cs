using System;
using System.Linq.Expressions;

namespace TinyShoppingCart.Domain.Entities
{
    public class QueryInclude : IQueryInclude
    {
        public string IncludeProperties { get;set; }
        public bool IsTracking { get;set; }
    }
}