using System;

namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public class AudViewModel : ViewModel, IAuditable<int>
    {
        public DateTime CreatedDate { get;set; }
        public int CreatedBy { get;set; }
        public DateTime? ModifiedDate { get;set; }
        public int? ModifiedBy { get;set; }
    }
}