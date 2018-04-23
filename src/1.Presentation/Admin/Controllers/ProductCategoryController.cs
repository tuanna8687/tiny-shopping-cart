using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Domain.Repositories;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;

namespace TinyShoppingCart.Server.Presentation.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult List([FromBody] DataTableParamViewModel paramViewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(paramViewModel == null)
            {
                return BadRequest();
            }

            var queryObj = _mapper.Map<DataTableParamViewModel, QueryObject>(paramViewModel);
            if(queryObj == null)
            {
                queryObj = new QueryObject();
            }  
            queryObj.IncludeProperties = "Parent";        

            var productCategories = _productCategoryRepository.ListAsync(queryObj);

            var viewModel = _mapper.Map<IQueryResult<ProductCategory>, QueryResultViewModel<ProductCategoryViewModel>>(productCategories.Result);
            if(viewModel != null)
            {
                viewModel.Draw = paramViewModel.Draw;
            }

            return Json(viewModel);
        }
    }
}