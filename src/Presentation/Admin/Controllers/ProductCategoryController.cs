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
using Microsoft.Extensions.Options;
using TinyShoppingCart.Presentation.Admin.Settings;
using TinyShoppingCart.Presentation.Admin.Filters.ActionFilters;

namespace TinyShoppingCart.Presentation.Admin.Controllers
{
    [ServiceFilter(typeof(ThemeActionFilter))]
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
            var productCategiesDto = _appService.GetFullTree();
            ViewProductCategoryViewModel viewModel = new ViewProductCategoryViewModel();

            viewModel.ProductCategories = _mapper.Map<IEnumerable<ProductCategoryDTO>, IEnumerable<ProductCategoryViewModel>>(productCategiesDto);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(int? parentId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            EditProductCategoryDTO dto = _appService.GetDataForCreate(parentId);
            if(dto == null)
            {
                return BadRequest();
            }

            EditProductCategoryViewModel viewModel = _mapper.Map<EditProductCategoryDTO, EditProductCategoryViewModel>(dto);
            if(viewModel == null)
            {
                return BadRequest();
            }

            return PartialView("_EditingFormPartial", viewModel);
        }


        [HttpPost]
        public IActionResult CreateData(EditProductCategoryViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(viewModel == null)
            {
                return BadRequest();
            }

            var dto = _mapper.Map<EditProductCategoryViewModel, ProductCategoryDTO>(viewModel);
            if(!_appService.Add(dto))
            {
                return BadRequest();
            }

            var fullTree = _appService.GetFullTree();

            ViewProductCategoryViewModel newViewModel = new ViewProductCategoryViewModel {
                SelectedProductCategoryId = dto.Id
            };
            newViewModel.ProductCategories = _mapper.Map<IEnumerable<ProductCategoryDTO>, IEnumerable<ProductCategoryViewModel>>(fullTree);

            return PartialView("_TreePartial", newViewModel); 
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            EditProductCategoryDTO dto = _appService.GetDataForEdit(id);
            if(dto == null)
            {
                return BadRequest();
            }

            EditProductCategoryViewModel viewModel = _mapper.Map<EditProductCategoryDTO, EditProductCategoryViewModel>(dto);
            if(viewModel == null)
            {
                return BadRequest();
            }

            return PartialView("_EditingFormPartial", viewModel);
        }

        [HttpPost]
        public IActionResult UpdateData(EditProductCategoryViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dto = _mapper.Map<EditProductCategoryViewModel, ProductCategoryDTO>(viewModel);
            if(!_appService.Update(dto))
            {
                return BadRequest();
            }

            var fullTree = _appService.GetFullTree();

            ViewProductCategoryViewModel newViewModel = new ViewProductCategoryViewModel {
                SelectedProductCategoryId = dto.Id
            };
            newViewModel.ProductCategories = _mapper.Map<IEnumerable<ProductCategoryDTO>, IEnumerable<ProductCategoryViewModel>>(fullTree);

            return PartialView("_TreePartial", newViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(!_appService.Delete(id))
            {
                return BadRequest();
            }
            
            return Json("OK");
        }

    }
}