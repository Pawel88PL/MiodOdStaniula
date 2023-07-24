using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class AddNewProductController : Controller
    {
        private readonly IAddProductService _addProductService;

        public AddNewProductController(IAddProductService addProductService)
        {
            _addProductService = addProductService;
        }


        [HttpGet]
        public  IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productId = await _addProductService.AddNewProductAsync(product);

            return RedirectToAction("Index","Store");
        }
    }
}
