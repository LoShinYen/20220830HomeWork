using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using SqlModels.DTOModels;
using System.Collections.Generic;
using static SqlModels.DTOModels.ProductVM;

namespace SqlModels.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            ProductVM result = new()
            {
                ProductList = _mapper.Map<List<ProductDato>>(_productService.ProductList())
            };
            return View(result);
        }

        

    }
}
