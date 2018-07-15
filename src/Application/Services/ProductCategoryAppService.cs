using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using TinyShoppingCart.Application.DTOs;
using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Domain.UnitOfWork;

namespace TinyShoppingCart.Application.Services
{
    public class ProductCategoryAppService : AppServiceBase, IProductCategoryAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<ProductCategoryDTO> GetFullTree()
        {
            // Get all data from database to EF create full tree automatically
            IEnumerable<ProductCategory> fullData = _unitOfWork.ProductCategoryRepository.GetAll();

            // Only get root node but from the root node we can travese all tree
            Func<ProductCategory, bool> predicate = c => c.ParentId == null;
            IEnumerable<ProductCategory> filteredData = fullData.Where(predicate);

            // Map from entity to DTO
            IEnumerable<ProductCategoryDTO> result = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDTO>>(filteredData);
            return result;
        }
    }
}