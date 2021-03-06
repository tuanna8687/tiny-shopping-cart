using System;

namespace TinyShoppingCart.Application.DTOs
{
    public class AudEntityDTO : EntityDTO
    {
        public DateTime CreatedDate { get;set; }
        public int CreatedBy { get;set; }
        public DateTime? ModifiedDate { get;set; }
        public int? ModifiedBy { get;set; }
    }
}