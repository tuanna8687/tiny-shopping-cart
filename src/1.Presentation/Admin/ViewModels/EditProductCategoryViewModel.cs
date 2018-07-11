using System.ComponentModel.DataAnnotations;

namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public class EditProductCategoryViewModel : AudViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name {get;set;}

        public int? ParentId {get;set;}
    }
}