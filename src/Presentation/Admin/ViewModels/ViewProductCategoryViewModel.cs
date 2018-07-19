using System.Collections.Generic;
using Newtonsoft.Json;

namespace TinyShoppingCart.Presentation.Admin.ViewModels
{
    public class ViewProductCategoryViewModel
    {
        public IList<ProductCategoryViewModel> ProductCategories {get;set;}
        public int? SelectedProductCategoryId {get;set;}
    }
}