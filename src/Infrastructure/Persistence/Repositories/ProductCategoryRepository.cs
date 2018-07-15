using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Domain.Repositories;
using TinyShoppingCart.Infrastructure.Persistence.Extensions;

namespace TinyShoppingCart.Infrastructure.Persistence.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(TinyShoppingCartDbContext dbContext) : base(dbContext)
        {
        }

        // public async Task<ProductCategory> GetAsync(int productCategoryId, IQueryObject queryObj = null)
        // {
        //     if(queryObj == null)
        //     {
        //         return await _dbSet.FindAsync(productCategoryId);
        //     }

        //     IQueryable<ProductCategory> query = _dbSet;
        //     query = query.ApplyTracking(queryObj);

        //     query = query.ApplyInclude(queryObj);

        //     return await query.SingleOrDefaultAsync(c => c.Id == productCategoryId);
        // }

        // public async Task<IQueryResult<ProductCategory>> ListAsync(IQueryObject queryObj = null)
        // {
        //     var result = new QueryResult<ProductCategory>();

        //     if(queryObj == null)
        //     {
        //         result.TotalItems = await _dbSet.CountAsync();
        //         result.Items = await _dbSet.ToListAsync();

        //         return result;
        //     }

        //     IQueryable<ProductCategory> query = _dbSet;

        //     if(!string.IsNullOrWhiteSpace(queryObj.Keyword))
        //     {
        //         query = query.Where(c => c.Name.Contains(queryObj.Keyword));
        //     }

        //     query = query.ApplyInclude(queryObj);

        //     var columnsMap = new Dictionary<string, Expression<Func<ProductCategory, object>>>() 
        //     {
        //         {"name", pc => pc.Name},
        //         //{"parentmame", pc => pc.Parent.Name}
        //     };
        //     query = query.ApplyOrdering(queryObj, columnsMap);

        //     result.TotalItems = await query.CountAsync();

        //     query = query.ApplyPaging(queryObj);

        //     result.Items = await query.ToListAsync();

        //     return result;
        // }

        // public async Task<IEnumerable<ProductCategory>> TreeListAsync(Func<ProductCategory, bool> predicate)
        // {
        //     // Get all data from database to EF builds hierarchy structure automatically.
        //     IList<ProductCategory> fullData = _dbSet.OrderBy(p => p.Id).ToList();

        //     if(predicate == null)
        //     {
        //         return fullData;
        //     }

        //     return fullData.Where(predicate);
        // }

        // public void Add(ProductCategory entity)
        // {
        //     _dbSet.Add(entity);
        // }

        // public void Update(ProductCategory entity)
        // {
        //     _context.Entry<ProductCategory>(entity).State = EntityState.Modified;
        // }

        // public void Delete(int productCategoryId)
        // {
        //     var entity = _dbSet.Find(productCategoryId);
        //     if(entity != null)
        //     {
        //         _dbSet.Remove(entity);
        //     }
        // }

        // public IEnumerable<ProductCategory> GetAll()
        // {
        //     return _dbSet;
        // }

        // public IEnumerable<ProductCategory> PartialTreeList(Expression<Func<ProductCategory, bool>> predicate)
        // {
        //     // Get a part of data from database to EF builds hierarchy structure partially.
        //     IList<ProductCategory> partialData = _dbSet.Where(predicate).OrderBy(p => p.Id).ToList();

        //     return partialData;
        // }

        // #region IDisposable Support
        // private bool disposedValue = false; // To detect redundant calls

        // protected virtual void Dispose(bool disposing)
        // {
        //     if (!disposedValue)
        //     {
        //         if (disposing)
        //         {
        //             // TODO: dispose managed state (managed objects).
        //             _context.Dispose();
        //         }

        //         // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        //         // TODO: set large fields to null.

        //         disposedValue = true;
        //     }
        // }

        // // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // // ~ProductCategoryRepository() {
        // //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        // //   Dispose(false);
        // // }

        // // This code added to correctly implement the disposable pattern.
        // public void Dispose()
        // {
        //     // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //     Dispose(true);
        //     // TODO: uncomment the following line if the finalizer is overridden above.
        //     // GC.SuppressFinalize(this);
        // }

        // #endregion
    }
}