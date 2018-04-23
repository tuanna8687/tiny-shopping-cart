using System.Collections.Generic;
using AutoMapper;
using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Presentation.Admin.MappingProfiles;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;
using Xunit;

namespace TinyShoppingCart.Server.Presentation.Admin.MappingProfiles
{
    public class QueryObjectMappingProfileTests : IClassFixture<QueryObjectMappingProfileFixture>
    {
        private readonly IMapper _mapper;
        
        public QueryObjectMappingProfileTests(QueryObjectMappingProfileFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_DataTableParamViewModelToQueryObject_Successfully()
        {
            // Arrange
            var dataTableParamViewModel = new DataTableParamViewModel()
            {
                Draw = 2,
                Columns = new List<ColumnParamViewModel>()
                {
                    new ColumnParamViewModel() { Name = "Column 1", Searchable = false, Orderable = true },
                    new ColumnParamViewModel() { Name = "Column 2", Searchable = true, Orderable = true},
                    new ColumnParamViewModel() { Name = "Column 3", Searchable = false, Orderable = false}
                },
                Order = new List<OrderParamViewModel>() 
                {
                    new OrderParamViewModel() { Column = 0, Dir = "ASC"},
                    new OrderParamViewModel() { Column = 1, Dir = "DESC"}
                },
                Start = 10,
                Length = 20,
                Search = new SearchParamViewModel()
                {
                    Value = "abc",
                    Regex = false
                }
            };

            // Act
            var result = _mapper.Map<DataTableParamViewModel, QueryObject>(dataTableParamViewModel);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.IncludeProperties);
            Assert.True(result.Keyword == dataTableParamViewModel.Search.Value);
            Assert.True(result.Start == dataTableParamViewModel.Start);
            Assert.True(result.PageSize == dataTableParamViewModel.Length);
            Assert.True(result.OrderBy == dataTableParamViewModel.Columns[0].Name);
            Assert.True(result.IsOrderAscending);

        }
    }
}