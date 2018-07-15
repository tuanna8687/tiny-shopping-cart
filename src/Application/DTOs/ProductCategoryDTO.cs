using System.Collections.Generic;

namespace TinyShoppingCart.Application.DTOs
{
    public class ProductCategoryDTO : AudEntityDTO
    {
        public string Name {get;set;}

        public int? ParentId {get;set;}

        public IList<ProductCategoryDTO> Children {get;set;}
    }
}