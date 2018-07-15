using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TinyShoppingCart.Infrastructure.Persistence.Repositories;
using TinyShoppingCart.Domain.Repositories;

namespace TinyShoppingCart.Infrastructure.Persistence.Repositories
{
    public class ProductCategoryRepositoryFixture : IDisposable
    {
        public DbContextOptions<TinyShoppingCartDbContext> ContextOptions {get; private set;}

        public DbConnection Connection {get;private set;}
        private readonly TinyShoppingCartDbContext _context;

        public ProductCategoryRepositoryFixture()
        {
            string connectionString = string.Format("Data Source=TinyShoppingCartDB_ProductCategoryTests_{0}.db", Guid.NewGuid());
            Connection = new SqliteConnection(connectionString);
            Connection.Open();

            var builder = new DbContextOptionsBuilder<TinyShoppingCartDbContext>();
            builder.UseSqlite(Connection);

            ContextOptions = builder.Options;

            _context = new TinyShoppingCartDbContext(ContextOptions);
            _context.Database.EnsureCreated();
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
                    Connection.Close();
                    Connection.Dispose();

                    _context.Database.EnsureDeleted();
                    _context.Dispose();

                    ContextOptions = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProductCategoryRepositoryFixture() {
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