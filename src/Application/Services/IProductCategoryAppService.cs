using System.Collections.Generic;
using TinyShoppingCart.Application.DTOs;

namespace TinyShoppingCart.Application.Services
{
    public interface IProductCategoryAppService
    {
         IEnumerable<ProductCategoryDTO> GetFullTree();
         EditProductCategoryDTO GetDataForCreate(int? parentProductCategoryId);
         bool Add(ProductCategoryDTO dto);
         EditProductCategoryDTO GetDataForEdit(int productCategoryId);
         bool Update(ProductCategoryDTO dto);
         bool Delete(int productCategoryId);
    }
}