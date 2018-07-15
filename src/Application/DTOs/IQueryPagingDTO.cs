namespace TinyShoppingCart.Application.DTOs
{
    public interface IQueryPagingDTO
    {
         int PageIndex {get;set;}
         int PageSize {get;set;}
    }
}