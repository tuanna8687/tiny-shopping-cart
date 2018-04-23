using System.Collections.Generic;
using System.Threading.Tasks;

using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Domain.Repositories;

namespace TinyShoppingCart.Server.Presentation.Admin.FakeRepositories
{
    public class FakeProductCategoryRepository : IProductCategoryRepository
    {
        public Task<ProductCategory> GetAsync(int productCategoryId, IQueryObject queryObj = null)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IQueryResult<ProductCategory>> ListAsync(IQueryObject queryObj = null)
        {
            var result = new QueryResult<ProductCategory>();
            result.TotalItems = 3;
            result.Items = new List<ProductCategory>() {
                new ProductCategory() { Id = 1, Name = "Category 1" },
                new ProductCategory() { Id = 2, Name = "Category 2"},
                new ProductCategory() { Id = 3, Name = "Category 3"},
            };

            return await Task.Run(() => result);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FakeProductCategoryRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}