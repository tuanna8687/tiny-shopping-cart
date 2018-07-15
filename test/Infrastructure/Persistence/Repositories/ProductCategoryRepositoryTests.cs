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

        public class TheGetByIdMethod : ProductCategoryRepositoryTestBase
        {
            public TheGetByIdMethod(ProductCategoryRepositoryFixture fixture) : base(fixture)
            {
            }

            private void CreateTestData()
            {
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    var dbSet = context.Set<ProductCategory>();
                    dbSet.Add(new ProductCategory { Id = 1, Name = "Men"});
                    dbSet.Add(new ProductCategory { Id = 2, Name = "Women"});
                    dbSet.Add(new ProductCategory { Id = 3, Name = "Clothes", ParentId = 1});

                    context.Database.UseTransaction(_transaction);
                    context.SaveChanges();
                }
            }

            [Fact]
            public void GetProductCategoryById_QueryObjectIsNull_Success()
            {
                // Arrange
                CreateTestData();

                // Act
                ProductCategory result;
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    context.Database.UseTransaction(_transaction);
                    var repository = new ProductCategoryRepository(context);
                    result = repository.GetById(3);
                }

                // Assert
                Assert.NotNull(result);
                Assert.Equal<int>(3, result.Id);
                Assert.True(result.Name == "Clothes");
                Assert.Null(result.Parent);
            }

            [Fact]
            public void GetProductCategoryById_NoTracking_Success()
            {
                // Arrange
                CreateTestData();

                // Act
                ProductCategory result;
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    context.Database.UseTransaction(_transaction);
                    var repository = new ProductCategoryRepository(context);

                    IQueryInclude queryObj = new QueryInclude { IsTracking = false };
                    result = repository.GetById(3, queryObj);
                    result.Name = "Test";
                    context.SaveChanges();
                    
                    result = repository.GetById(3, queryObj);
                }

                // Assert
                Assert.NotNull(result);
                Assert.Equal<int>(3, result.Id);
                Assert.True(result.Name == "Clothes");
                Assert.Null(result.Parent);
            }

            [Fact]
            public void GetProductCategoryById_HaveTracking_Success()
            {
                // Arrange
                CreateTestData();

                // Act
                ProductCategory result;
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    context.Database.UseTransaction(_transaction);
                    var repository = new ProductCategoryRepository(context);

                    IQueryInclude queryObj = new QueryInclude { IsTracking = true };
                    result = repository.GetById(3, queryObj);
                    result.Name = "Test";
                    context.SaveChanges();
                    
                    result = repository.GetById(3, queryObj);
                }

                // Assert
                Assert.NotNull(result);
                Assert.Equal<int>(3, result.Id);
                Assert.True(result.Name == "Test");
                Assert.Null(result.Parent);
            }

            [Fact]
            public void GetProductCategoryById_IncludeParent_Success()
            {
                // Arrange
                CreateTestData();

                // Act
                ProductCategory result;
                using(var context = new TinyShoppingCartDbContext(_options))
                {
                    context.Database.UseTransaction(_transaction);
                    var repository = new ProductCategoryRepository(context);

                    IQueryInclude queryObj = new QueryInclude { IncludeProperties = "Parent" };
                    result = repository.GetById(3, queryObj);
                }

                // Assert
                Assert.NotNull(result);
                Assert.Equal<int>(3, result.Id);
                Assert.True(result.Name == "Clothes");
                Assert.NotNull(result.Parent);
                Assert.Equal<string>("Men",result.Parent.Name);
            }
        }

    }
}