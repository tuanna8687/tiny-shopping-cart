using System;

namespace TinyShoppingCart.Domain.Entities
{
    public class AudEntity : Entity, IAuditable<int>
    {
        public DateTime CreatedDate { get;set; }
        public int CreatedBy { get;set; }
        public DateTime? ModifiedDate { get;set; }
        public int? ModifiedBy { get;set; }
    }
}