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

        public IActionResult Edit(int id)
        {
            ProductVM result = new()
            {
                EditProduct = _mapper.Map<ProductDato>(_productService.EditProduct(id))
            };
            if (TempData["Edit"] != null)
            {
                string msg = (string)TempData["Edit"];
                ViewData["msg"] = msg;
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] ProductVM model)
        {
            var result = _productService.EditProduct(model);
            TempData["Edit"] = result.msg;
            return RedirectToAction("Edit",model.EditProduct.ProductId);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}
