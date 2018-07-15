using System.Collections.Generic;
using TinyShoppingCart.Application.DTOs;

namespace TinyShoppingCart.Application.Services
{
    public interface IProductCategoryAppService
    {
         IEnumerable<ProductCategoryDTO> GetFullTree();
    }
}