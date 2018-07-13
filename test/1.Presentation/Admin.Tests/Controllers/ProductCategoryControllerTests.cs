using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Domain.Repositories;
using TinyShoppingCart.Server.Presentation.Admin.Controllers;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;
using TinyShoppingCart.Server.Presentation.Admin.FakeRepositories;

namespace TinyShoppingCart.Server.Presentation.Admin.Controllers
{
    public class ProductCategoryControllerTests
    {
        public class ProductCategoryControllerTestBase : IDisposable
        {
            //protected ProductCategoryController _underTestController;
            protected IProductCategoryRepository _fakeRepository;
            protected Mock<IMapper> _mockMapper;

            public ProductCategoryControllerTestBase()
            {
                _fakeRepository = new FakeProductCategoryRepository();
                _mockMapper = new Mock<IMapper>();
                //_underTestController = new ProductCategoryController(_fakeRepository, _mockMapper.Object);
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
                        _fakeRepository.Dispose();
                        _mockMapper = null;
                        //_underTestController.Dispose();
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~ProductCategoryControllerTestBase() {
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

        public class TheIndexMethod: ProductCategoryControllerTestBase
        {
            [Fact]
            public void ReturnDefaultIndexView()
            {
                // // Arrange

                // // Act
                // var result = _underTestController.Index();

                // // Assert
                // Assert.IsType<ViewResult>(result);
                // Assert.True(string.IsNullOrEmpty((result as ViewResult).ViewName));
                // Assert.True((result as ViewResult).Model == null);
            }
        }

        public class TheListMethod: ProductCategoryControllerTestBase
        {
            // [Fact]
            // public void ReturnBadRequest_DataTableParamIsNull()
            // {
            //     // Arrange

            //     // Act
            //     var result = _underTestController.List(null);

            //     // Assert
            //     Assert.IsType<BadRequestResult>(result);
            // }

            // [Fact]
            // public void ReturnBadRequest_ModelBindingIsFailed()
            // {
            //     // Arrange
            //     DataTableParamViewModel paramViewModel = new DataTableParamViewModel();
            //     _underTestController.ModelState.AddModelError("Columns", "Required");

            //     // Act
            //     var result = _underTestController.List(paramViewModel);

            //     // Assert
            //     Assert.IsType<BadRequestResult>(result);
            // }

            // [Fact]
            // public void ReturnJson()
            // {
            //     // Arrange
            //     var fakeProductCategories = _fakeRepository.ListAsync().Result;
            //     QueryResultViewModel<ProductCategoryViewModel> mockResult = new QueryResultViewModel<ProductCategoryViewModel>()
            //     {
            //         Draw = 1,
            //         RecordsTotal = fakeProductCategories.TotalItems,
            //         RecordsFiltered = fakeProductCategories.TotalItems,
            //         Data = fakeProductCategories.Items.Select(c => new ProductCategoryViewModel() { Id = c.Id, Name = c.Name, ParentName = c.Parent != null ? c.Parent.Name : null})
            //     };
                
            //     _mockMapper.Setup(mapper => 
            //             mapper.Map<IQueryResult<ProductCategory>, QueryResultViewModel<ProductCategoryViewModel>>(It.IsAny<IQueryResult<ProductCategory>>())
            //         ).Returns(mockResult);

            //     _underTestController = new ProductCategoryController(_fakeRepository, _mockMapper.Object);
                
            //     DataTableParamViewModel paramViewModel = new DataTableParamViewModel();

            //     // Act
            //     var result = _underTestController.List(paramViewModel);
            
            //     // Assert
            //     Assert.IsType<JsonResult>(result);
            //     Assert.IsType<QueryResultViewModel<ProductCategoryViewModel>>((result as JsonResult).Value);
            //     var actualValue = (result as JsonResult).Value as QueryResultViewModel<ProductCategoryViewModel>;
            //     Assert.True(actualValue.Draw == paramViewModel.Draw);
            //     Assert.True(actualValue.RecordsTotal == mockResult.RecordsTotal);
            //     Assert.True(actualValue.RecordsFiltered == mockResult.RecordsFiltered);
            // }
        }
    }
}