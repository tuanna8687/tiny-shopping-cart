using System.Collections.Generic;

namespace TinyShoppingCart.Server.Domain.Entities
{
    public class QueryResult<T> : IQueryResult<T>
    {
        public int TotalItems {get;set;}

        public IEnumerable<T> Items {get;set;}
    }
}