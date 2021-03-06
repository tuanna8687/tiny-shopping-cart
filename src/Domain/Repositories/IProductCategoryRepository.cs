using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TinyShoppingCart.Domain.Entities;

namespace TinyShoppingCart.Domain.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        //  Task<ProductCategory> GetAsync(int productCategoryId, IQueryObject queryObj = null);
        //  Task<IQueryResult<ProductCategory>> ListAsync(IQueryObject queryObj = null);

        //  Task<IEnumerable<ProductCategory>> TreeListAsync(Func<ProductCategory, bool> predicate);
        //  void Add(ProductCategory entity);
        //  void Update(ProductCategory entity);
        //  void Delete(int productCategoryId);

        //  IEnumerable<ProductCategory> GetAll();

        //  IEnumerable<ProductCategory> PartialTreeList(Expression<Func<ProductCategory, bool>> predicate);
    }
}