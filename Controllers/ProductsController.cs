using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IProductService _productService;

        public ProductsController(IWarehouseService warehouseService, IProductService productService)
        {
            _warehouseService = warehouseService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string filterCondition)
        {
            var products = await _warehouseService.GetAllProductsAsync();
            products = _productService.Sort(products, sortOrder);
            products = _productService.Filter(products, filterCondition);
            ViewBag.FilterCondition = string.IsNullOrEmpty(filterCondition) ? "Wszystkie produkty" : filterCondition;

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string sortOrder, string filterCondition)
        {
            var products = await _warehouseService.GetAllProductsAsync();
            products = _productService.Sort(products, sortOrder);
            products = _productService.Filter(products, filterCondition);

            return PartialView("_ProductList", products);
        }



        [HttpGet]
        public async Task<IActionResult> Details(int ProductId)
        {
            var product = await _warehouseService.GetProductAsync(ProductId);

            if (product == null)
            {
                return View("_NotFound");
            }

            return View(product);
        }

    }
}
