using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyShoppingCart.Server.Domain.Entities;

namespace TinyShoppingCart.Server.Domain.Repositories
{
    public interface IProductCategoryRepository : IDisposable
    {
         Task<ProductCategory> GetAsync(int productCategoryId, IQueryObject queryObj = null);
         Task<IQueryResult<ProductCategory>> ListAsync(IQueryObject queryObj = null);
    }
}