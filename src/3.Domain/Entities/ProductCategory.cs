using System.Collections.Generic;

namespace TinyShoppingCart.Server.Domain.Entities
{
    public class ProductCategory : VerAudEntity
    {
        public string Name {get;set;}

        public int? ParentId {get;set;}

        public ProductCategory Parent {get;set;}

        public IList<ProductCategory> Children {get;set;}
    }
}