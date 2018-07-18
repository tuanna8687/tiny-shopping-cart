using System.Collections.Generic;
using Newtonsoft.Json;

namespace TinyShoppingCart.Presentation.Admin.ViewModels
{
    public class ProductCategoryViewModel : AudViewModel
    { 
        [JsonProperty(nameof(Name))]
        public string Name {get;set;}

        public int? ParentId {get;set;}

        public IEnumerable<ProductCategoryViewModel> Children {get;set;}
    }
}