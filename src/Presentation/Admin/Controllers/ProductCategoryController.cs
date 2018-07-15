using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Domain.Repositories;
using TinyShoppingCart.Presentation.Admin.ViewModels;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using System.Linq;
using System;
using TinyShoppingCart.Domain.UnitOfWork;
using TinyShoppingCart.Application.Services;
using TinyShoppingCart.Application.DTOs;

namespace TinyShoppingCart.Presentation.Admin.Controllers
{
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryAppService _appService;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryAppService appService,
                                        IMapper mapper)
        {
            _mapper = mapper;
            _appService = appService;
        }

        public IActionResult Index()
        {
            var dtos = _appService.GetFullTree();

            IEnumerable<ViewProductCategoryViewModel> viewModel = _mapper.Map<IEnumerable<ProductCategoryDTO>, IEnumerable<ViewProductCategoryViewModel>>(dtos);

            return View(viewModel);
        }



        // [HttpPost]
        // public IActionResult Create(EditProductCategoryViewModel viewModel)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         viewModel.CreatedBy = 1;
        //         viewModel.CreatedDate = DateTime.Now;

        //         var productCategory = _mapper.Map<EditProductCategoryViewModel, ProductCategory>(viewModel);
        //         _productCategoryRepository.Add(productCategory);
        //         _unitOfWork.Commit();

        //         // Get full tree to reload client tree view
        //         var vm = _mapper.Map<ProductCategory, ViewProductCategoryViewModel>(productCategory);
        //         return Json(vm);
        //     }

        //     return PartialView("_CreatePartial", viewModel);
        // }

        // [HttpPost]
        // public IActionResult Delete(int id)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest();
        //     }

        //     var fullData = _productCategoryRepository.GetAll();

        //     var productCategory = fullData.SingleOrDefault(c => c.Id == id);
        //     if(productCategory == null)
        //     {
        //         return BadRequest();
        //     }

        //     DeleteChildCategories(fullData, productCategory.Id);
        //     _productCategoryRepository.Delete(id);
        //     _unitOfWork.Commit();
        //     return Json("OK");
        // }

        // [HttpPost]
        // public IActionResult Update(int id)
        // {
        //     IQueryObject queryObj = new QueryObject {
        //         IsTracking = false
        //     };

        //     var productCategory = _productCategoryRepository.GetAsync(id, queryObj);
        //     if(productCategory == null)
        //     {
        //         return BadRequest();
        //     }
        //     var viewModel = _mapper.Map<ProductCategory, EditProductCategoryViewModel>(productCategory.Result);

        //     var partialData = _productCategoryRepository.PartialTreeList(c => c.Id != id);
        //     var filteredData = partialData.Where(c => c.ParentId == null).ToList();
            
        //     viewModel.FullCategories = _mapper.Map<IList<ProductCategory>, IList<ViewProductCategoryViewModel>>(filteredData);

        //     return PartialView("_UpdatePartial", viewModel);
        // }

        // [HttpPost]
        // public IActionResult UpdateData(EditProductCategoryViewModel viewModel)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest();
        //     }

        //     var queryObj = new QueryObject {IsTracking = false};
        //     var result = _productCategoryRepository.GetAsync(viewModel.Id, queryObj);
        //     if(result.Result == null)
        //     {
        //         return BadRequest();
        //     }

        //     var entity = _mapper.Map<EditProductCategoryViewModel, ProductCategory>(viewModel, result.Result);
        //     _productCategoryRepository.Update(entity);
        //     _unitOfWork.Commit();

        //     var fullTree = _productCategoryRepository.TreeListAsync(c => c.ParentId == null);
        //     var fullTreeViewModel = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ViewProductCategoryViewModel>>(fullTree.Result);

        //     return PartialView("_TreePartial", fullTreeViewModel); 
        // }

        // private void DeleteChildCategories(IEnumerable<ProductCategory> fullData, int productCategoryId)
        // {
        //     var children = fullData.Where(c => c.ParentId == productCategoryId);

        //     foreach (var child in children)
        //     {
        //         DeleteChildCategories(fullData, child.Id);
        //         _productCategoryRepository.Delete(child.Id);
        //     }
        // }
    }
}