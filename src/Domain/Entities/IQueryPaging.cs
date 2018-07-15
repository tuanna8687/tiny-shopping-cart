using System;
using System.Linq.Expressions;

namespace TinyShoppingCart.Domain.Entities
{
    public interface IQueryPaging
    {
         int PageIndex {get;set;}
         int PageSize {get;set;}
    }
}