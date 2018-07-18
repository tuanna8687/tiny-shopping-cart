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
            IList<ProductCategory> fullData = _unitOfWork.ProductCategoryRepository.GetAll().ToList();

            // Only get root node but from the root node we can travese all tree
            Func<ProductCategory, bool> predicate = c => c.ParentId == null;
            IEnumerable<ProductCategory> filteredData = fullData.Where(predicate);

            // Map from entity to DTO
            IEnumerable<ProductCategoryDTO> result = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryDTO>>(filteredData);
            return result;
        }

        public EditProductCategoryDTO GetDataForCreate(int? parentProductCategoryId)
        {
            var dto = new EditProductCategoryDTO {
                ParentId = parentProductCategoryId
            };

            dto.ParentCategories = GetFullTree(null);
            return  dto;
        }

        private IList<ProductCategoryDTO> GetFullTree(int? exceptProductCategoryId)
        {
            IEnumerable<ProductCategory> fullDataWithoutExceptingId = null;
            if(exceptProductCategoryId != null)
            {
                fullDataWithoutExceptingId = _unitOfWork.ProductCategoryRepository.Get(c => c.Id != exceptProductCategoryId).ToList();
            }
            else
            {
                fullDataWithoutExceptingId = _unitOfWork.ProductCategoryRepository.GetAll().ToList();
            }
            
            var filteredData = fullDataWithoutExceptingId.Where(c => c.ParentId == null);

            var filteredDtos = _mapper.Map<IEnumerable<ProductCategory>, IList<ProductCategoryDTO>>(filteredData);
            if(filteredDtos != null)
            {
                var emptyItem = new ProductCategoryDTO {
                    Id = 0,
                    Name = "--- Select ---"
                };
                filteredDtos.Insert(0, emptyItem);
            }

            return filteredDtos;
        }

        public bool Add(ProductCategoryDTO dto)
        {
            var entity = _mapper.Map<ProductCategoryDTO, ProductCategory>(dto);
            if(entity == null)
            {
                return false;
            }
            if(entity.ParentId <= 0)
            {
                entity.ParentId = null;
            }
            entity.CreatedDate = DateTime.Now;

            _unitOfWork.ProductCategoryRepository.Add(entity);
            _unitOfWork.Commit();

            dto.Id = entity.Id;
            return true;
        }

        public EditProductCategoryDTO GetDataForEdit(int productCategoryId)
        {
            // Get product category without tracking by EF
            IQueryInclude queryObj = new QueryInclude { IsTracking = false};
            var entity = _unitOfWork.ProductCategoryRepository.GetById(productCategoryId, queryObj);
            if(entity == null)
            {
                return null;
            }

            EditProductCategoryDTO dto = _mapper.Map<ProductCategory, EditProductCategoryDTO>(entity);
            if(dto == null)
            {
                return null;
            }

            // Get all parent categories that does not contain the editing product catetory
            dto.ParentCategories = GetFullTree(productCategoryId);

            return dto;
        }

        public bool Update(ProductCategoryDTO dto)
        {
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var entity = _unitOfWork.ProductCategoryRepository.GetById(dto.Id);
            if(entity == null)
            {
                return false;
            }

            entity = _mapper.Map<ProductCategoryDTO, ProductCategory>(dto, entity, 
                                                                    (options) => {
                                                                        //options.ConfigureMap().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
                                                                        ///options.ConfigureMap().ForSourceMember(x => x.CreatedDate, opt => opt.Ignore());
                                                                        //options.ConfigureMap().ForMember(x => x.CreatedBy, opt => opt.Ignore());
                                                                        //options.ConfigureMap().ForMember(x => x.CreatedDate, opt => opt.Ignore());
                                                                    });
            if(entity.ParentId <= 0)
            {
                entity.ParentId = null;
            }
            entity.ModifiedDate = DateTime.Now;

            _unitOfWork.ProductCategoryRepository.Update(entity);
            _unitOfWork.Commit();

            return true;
        }

        public bool Delete(int productCategoryId)
        {
            IQueryInclude queryObj = new QueryInclude { IsTracking = false};

            var fullData = _unitOfWork.ProductCategoryRepository.GetAll(queryObj).ToList();

            var productCategory = fullData.SingleOrDefault(c => c.Id == productCategoryId);
            if(productCategory == null)
            {
                return false;
            }

            DeleteChildCategories(fullData, productCategory.Id);
            _unitOfWork.ProductCategoryRepository.Delete(productCategory);

            _unitOfWork.Commit();
            return true;
        }

        private void DeleteChildCategories(IList<ProductCategory> fullData, int productCategoryId)
        {
            var children = fullData.Where(c => c.ParentId == productCategoryId);

            foreach (var child in children)
            {
                DeleteChildCategories(fullData, child.Id);
                _unitOfWork.ProductCategoryRepository.Delete(child);
            }
        }
    }
}