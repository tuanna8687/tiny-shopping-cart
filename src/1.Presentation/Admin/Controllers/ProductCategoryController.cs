using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Domain.Repositories;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using System.Linq;
using System;
using TinyShoppingCart.Server.Domain.UnitOfWork;

namespace TinyShoppingCart.Server.Presentation.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, 
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var productCategories = _productCategoryRepository.TreeListAsync(x => x.ParentId == null);
            IEnumerable<ViewProductCategoryViewModel> viewModel = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ViewProductCategoryViewModel>>(productCategories.Result);

            return View(viewModel);
        }

        public IActionResult GetData(IDataTablesRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(request == null)
            {
                return BadRequest();
            }

            var queryObj = _mapper.Map<IDataTablesRequest, QueryObject>(request);
            if(queryObj == null)
            {
                queryObj = new QueryObject();
            }  
            queryObj.IncludeProperties = "Parent";        

            var productCategories = _productCategoryRepository.ListAsync(queryObj);

            var queryResult = _mapper.Map<IQueryResult<ProductCategory>, QueryResultViewModel<ViewProductCategoryViewModel>>(productCategories.Result);
            var response = DataTablesResponse.Create(request, 
                                                    queryResult.RecordsTotal, 
                                                    queryResult.RecordsFiltered, 
                                                    queryResult.Items);
            
            return new DataTablesJsonResult(response, true);
        }

        [HttpPost]
        public IActionResult Create(EditProductCategoryViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                viewModel.CreatedBy = 1;
                viewModel.CreatedDate = DateTime.Now;

                var productCategory = _mapper.Map<EditProductCategoryViewModel, ProductCategory>(viewModel);
                _productCategoryRepository.Add(productCategory);
                _unitOfWork.Commit();

                // Get full tree to reload client tree view
                var vm = _mapper.Map<ProductCategory, ViewProductCategoryViewModel>(productCategory);
                return Json(vm);
            }

            return PartialView("_CreatePartial", viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var fullData = _productCategoryRepository.GetAll();

            var productCategory = fullData.SingleOrDefault(c => c.Id == id);
            if(productCategory == null)
            {
                return BadRequest();
            }

            DeleteChildCategories(fullData, productCategory.Id);
            _productCategoryRepository.Delete(id);
            _unitOfWork.Commit();
            return Json("OK");
        }

        private void DeleteChildCategories(IEnumerable<ProductCategory> fullData, int productCategoryId)
        {
            var children = fullData.Where(c => c.ParentId == productCategoryId);

            foreach (var child in children)
            {
                DeleteChildCategories(fullData, child.Id);
                _productCategoryRepository.Delete(child.Id);
            }
        }
    }
}