namespace TinyShoppingCart.Server.Domain.Entities
{
    public class QueryObject : IQueryObject
    {
        public string IncludeProperties { get; set; }
        public string Keyword { get;set; }
        public string OrderBy { get;set; }
        public bool IsOrderAscending { get;set; }
        public int Start { get;set; }
        public int PageSize { get;set; }
        public bool IsTracking { get;set; }
    }
}