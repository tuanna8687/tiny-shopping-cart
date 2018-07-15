using System.Threading.Tasks;
using TinyShoppingCart.Domain.Repositories;
using TinyShoppingCart.Domain.UnitOfWork;
using TinyShoppingCart.Infrastructure.Persistence.Repositories;

namespace TinyShoppingCart.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TinyShoppingCartDbContext _dbContext;

        private IProductCategoryRepository _productCategoryRepository;

        public UnitOfWork(TinyShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductCategoryRepository ProductCategoryRepository 
        {
            get 
            {
                if(_productCategoryRepository == null)
                {
                    _productCategoryRepository = new ProductCategoryRepository(_dbContext);
                }

                return _productCategoryRepository;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
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
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
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