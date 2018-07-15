using System;
using System.Linq.Expressions;

namespace TinyShoppingCart.Domain.Entities
{
    public interface IQueryInclude
    {
         string IncludeProperties {get;set;}
         bool IsTracking {get;set;}
    }
}