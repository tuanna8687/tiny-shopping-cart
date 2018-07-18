using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyShoppingCart.Application.DTOs
{
    public class EditProductCategoryDTO : AudEntityDTO
    {
        public string Name {get;set;}

        public int? ParentId {get;set;}

        public IList<ProductCategoryDTO> ParentCategories {get;set;}
    }
}