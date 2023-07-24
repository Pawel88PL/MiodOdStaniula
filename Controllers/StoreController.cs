using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class StoreController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public StoreController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productsList = await _warehouseService.GetAllProductsAsync();
            return View(productsList);
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
