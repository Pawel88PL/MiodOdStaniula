using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace MiodOdStaniula.Controllers
{
    public class AddNewProductController : Controller
    {
        private readonly IAddProductService _addProductService;
        private readonly IFileUploadService _fileUploadService;

        public AddNewProductController(IAddProductService addProductService, IFileUploadService fileUploadService)
        {
            _addProductService = addProductService;
            _fileUploadService = fileUploadService;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            if (productViewModel.ProductImage != null)
            {
                productViewModel.PhotoUrlAddress = await _fileUploadService.UploadFileAsync(productViewModel.ProductImage);
            }

            var product = new Product
            {
                Name = productViewModel.Name,
                Priority = productViewModel.Priority,
                Description = productViewModel.Description,
                Price = productViewModel.Price,
                Weight = productViewModel.Weight,
                AmountAvailable = productViewModel.AmountAvailable,
                CategoryId = productViewModel.CategoryId,
                PhotoUrlAddress = productViewModel.PhotoUrlAddress
            };

            await _addProductService.AddNewProductAsync(product);

            return RedirectToAction("Index", "Warehouse");
        }

    }
}
