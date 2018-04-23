using System.Collections.Generic;

namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public class QueryResultViewModel<T> : IQueryResultViewModel<T>
    {
        public int Draw {get;set;}
        public int RecordsTotal {get;set;}
        public int RecordsFiltered {get;set;}
        public IEnumerable<T> Data {get;set;}
        public string Error {get;set;}
    }
}