using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;
using Xunit;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace TinyShoppingCart.Server.Presentation.Admin.ModelBinders
{
    public class DataTableParamViewModelTests
    {
        [Fact]
        public void RetrieveModelFromJsonSuccessfully_UsingDefaultModelBinder()
        {
            // // Arrange
            // var httpContext = new DefaultHttpContext();
            // string plainPostData = "{\"draw\":1,\"columns\":[{\"data\":\"name\",\"name\":\"name\",\"searchable\":true,\"orderable\":true,\"search\":{\"value\":\"\",\"regex\":false}},{\"data\":\"parentName\",\"name\":\"parentName\",\"searchable\":true,\"orderable\":true,\"search\":{\"value\":\"\",\"regex\":false}},{\"data\":\"\",\"name\":\"\",\"searchable\":false,\"orderable\":false,\"search\":{\"value\":\"\",\"regex\":false}}],\"order\":[{\"column\":0,\"dir\":\"asc\"}],\"start\":0,\"length\":25,\"search\":{\"value\":\"\",\"regex\":false}}";
            // byte[] postData = Encoding.UTF8.GetBytes(plainPostData);
            // httpContext.Request.Body = new MemoryStream(postData);
            // httpContext.Request.ContentType = "application/json";

            // var bindingContext = GetBindingContext(typeof(DataTableParamViewModel), httpContext);

            // IList<IInputFormatter> formatters = new List<IInputFormatter>()
            // {
            //     new JsonInputFormatter(NullLogger.Instance, new JsonSerializerSettings(), ArrayPool<char>.Shared, new DefaultObjectPoolProvider())
            // };
            // var binder = CreateBinder(formatters);

            // // Act
            // binder.BindModelAsync(bindingContext);

            // // Assert
            // Assert.True(bindingContext.Result.IsModelSet);
            // Assert.NotNull(bindingContext.Result.Model);
        }

        // [Fact]
        // public void RetrieveModelFromJsonSuccessfully_UsingBodyModelBinder()
        // {
        //     // Arrange
        //     var mockHttpContext = new Mock<HttpContext>();

        //     string plainPostData = "{\"draw\":1,\"columns\":[{\"data\":\"name\",\"name\":\"name\",\"searchable\":true,\"orderable\":true,\"search\":{\"value\":\"\",\"regex\":false}},{\"data\":\"parentName\",\"name\":\"parentName\",\"searchable\":true,\"orderable\":true,\"search\":{\"value\":\"\",\"regex\":false}},{\"data\":\"\",\"name\":\"\",\"searchable\":false,\"orderable\":false,\"search\":{\"value\":\"\",\"regex\":false}}],\"order\":[{\"column\":0,\"dir\":\"asc\"}],\"start\":0,\"length\":25,\"search\":{\"value\":\"\",\"regex\":false}}";
        //     byte[] postData = Encoding.UTF8.GetBytes(plainPostData);

        //     mockHttpContext.Setup(x => x.Request.Body).Returns(new MemoryStream(postData));
        //     mockHttpContext.Setup(x => x.Request.ContentType).Returns("application/json");

        //     var bindingContext = CreateBindingContext(typeof(DataTableParamViewModel), mockHttpContext.Object);

        //     IList<IInputFormatter> formatters = new List<IInputFormatter>()
        //     {
        //         new JsonInputFormatter(NullLogger.Instance, new JsonSerializerSettings(), ArrayPool<char>.Shared, new DefaultObjectPoolProvider())
        //     };
        //     var binder = CreateBinder(formatters);

        //     // Act
        //     binder.BindModelAsync(bindingContext);

        //     // Assert
        //     Assert.True(bindingContext.Result.IsModelSet);
        //     Assert.NotNull(bindingContext.Result.Model);
        // }

        private static BodyModelBinder CreateBinder(IList<IInputFormatter> formatters)
        {
            var binder = new BodyModelBinder(formatters, new TestHttpRequestStreamReaderFactory());
            return binder;
        }

        private static DefaultModelBindingContext GetBindingContext(
            Type modelType,
            HttpContext httpContext = null,
            IModelMetadataProvider metadataProvider = null)
        {
            if (httpContext == null)
            {
                httpContext = new DefaultHttpContext();
            }

            if (metadataProvider == null)
            {
                metadataProvider = new EmptyModelMetadataProvider();
            }

            var bindingContext = new DefaultModelBindingContext
            {
                ActionContext = new ActionContext()
                {
                    HttpContext = httpContext,
                },
                FieldName = "someField",
                IsTopLevelObject = true,
                ModelMetadata = metadataProvider.GetMetadataForType(modelType),
                ModelName = "someName",
                ValueProvider = Mock.Of<IValueProvider>(),
                ModelState = new ModelStateDictionary(),
                BindingSource = BindingSource.Body,
            };

            return bindingContext;
        }

    }
}