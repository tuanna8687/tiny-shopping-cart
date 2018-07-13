using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

using TinyShoppingCart.Infrastructure.Persistence.Repositories;
using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Domain.Repositories;
using System.Collections.Generic;

namespace TinyShoppingCart.Infrastructure.Persistence.Repositories
{
    public class ProductCategoryRepositoryTests
    {
        public class ProductCategoryRepositoryTestBase : IClassFixture<ProductCategoryRepositoryFixture>, IDisposable
        {
            private readonly ProductCategoryRepositoryFixture _fixture;
            protected readonly DbTransaction _transaction;

            protected readonly DbContextOptions<TinyShoppingCartDbContext> _options;

            public ProductCategoryRepositoryTestBase(ProductCategoryRepositoryFixture fixture)
            {
                _fixture = fixture;
                _options = fixture.ContextOptions;

                _transaction = fixture.Connection.BeginTransaction();
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
                        _transaction.Rollback();
                        _transaction.Dispose();
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~ProductCategoryRepositoryTests() {
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

        public class TheGetAsyncMethod : ProductCategoryRepositoryTestBase
        {
            public TheGetAsyncMethod(ProductCategoryRepositoryFixture fixture) : base(fixture)
            {
            }

            [Fact]
            public void GetProductCategoryById_WithoutIncludeProperties_Successfully()
            {
                // Arrange
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    var dbSet = context.Set<ProductCategory>();
                    dbSet.Add(new ProductCategory { Id = 1, Name = "Men"});
                    dbSet.Add(new ProductCategory { Id = 2, Name = "Women"});
                    dbSet.Add(new ProductCategory { Id = 3, Name = "Clothes", ParentId = 1});

                    context.Database.UseTransaction(_transaction);
                    context.SaveChanges();
                }

                // Act
                ProductCategory result;
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    context.Database.UseTransaction(_transaction);
                    var repository = new ProductCategoryRepository(context);
                    result = repository.GetAsync(3).Result;
                }

                // Assert
                Assert.NotNull(result);
                Assert.Equal<int>(3, result.Id);
                Assert.True(result.Name == "Clothes");
                Assert.Null(result.Parent);
            }

            [Fact]
            public void GetProductCategoryById_IncludeParentProperty_Successfully()
            {
                // Arrange
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    var dbSet = context.Set<ProductCategory>();
                    dbSet.Add(new ProductCategory { Id = 1, Name = "Men"});
                    dbSet.Add(new ProductCategory { Id = 2, Name = "Women"});
                    dbSet.Add(new ProductCategory { Id = 3, Name = "Clothes", ParentId = 1});

                    context.Database.UseTransaction(_transaction);
                    context.SaveChanges();
                }

                // Act
                ProductCategory result;
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    context.Database.UseTransaction(_transaction);
                    var repository = new ProductCategoryRepository(context);
                    result = repository.GetAsync(3, new QueryObject { IncludeProperties = "Parent" }).Result;
                }

                // Assert
                Assert.NotNull(result);
                Assert.Equal<int>(3, result.Id);
                Assert.True(result.Name == "Clothes");
                Assert.NotNull(result.Parent);
                Assert.True(result.Parent.Name == "Men");
            }
        }

        public class TheListAsyncMethod : ProductCategoryRepositoryTestBase
        {
            public TheListAsyncMethod(ProductCategoryRepositoryFixture fixture) : base(fixture)
            {
            }

            [Fact]
            public void ListAllProductCategories_QueryObjectIsNull_Successfully()
            {
                // Arrange
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    var dbSet = context.Set<ProductCategory>();
                    dbSet.Add(new ProductCategory { Id = 1, Name = "Men"});
                    dbSet.Add(new ProductCategory { Id = 2, Name = "Women"});
                    dbSet.Add(new ProductCategory { Id = 3, Name = "Clothes", ParentId = 1});

                    context.Database.UseTransaction(_transaction);
                    context.SaveChanges();
                }

                // Act
                IQueryResult<ProductCategory> result;
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    context.Database.UseTransaction(_transaction);
                    var repository = new ProductCategoryRepository(context);
                    result = repository.ListAsync().Result;
                }

                // Assert
                Assert.NotNull(result);
                Assert.Equal<int>(3, result.TotalItems);
                var totalItems = new List<ProductCategory>(result.Items);
                Assert.Equal<string>("Women", totalItems[1].Name);
            }
        }

    }
}