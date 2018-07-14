using System.Collections.Generic;
using Newtonsoft.Json;

namespace TinyShoppingCart.Presentation.Admin.ViewModels
{
    public class ViewProductCategoryViewModel : AudViewModel
    {
        [JsonProperty(nameof(Name))]
        public string Name {get;set;}

        public int? ParentId {get;set;}

        public IEnumerable<ViewProductCategoryViewModel> Children {get;set;}
    }
}