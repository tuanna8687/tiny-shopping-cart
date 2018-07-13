using System.Collections.Generic;

namespace TinyShoppingCart.Presentation.Admin.ViewModels
{
    public class QueryResultViewModel<T> : IQueryResultViewModel<T>
    {
        public int RecordsTotal {get;set;}
        public int RecordsFiltered {get;set;}
        public IEnumerable<T> Items {get;set;}
    }
}