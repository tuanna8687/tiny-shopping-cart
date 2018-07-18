using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyShoppingCart.Presentation.Admin.ViewModels
{
    public class EditProductCategoryViewModel : AudViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name {get;set;}

        public int? ParentId {get;set;}

        public IEnumerable<ProductCategoryViewModel> ParentCategories {get;set;}
    }
}