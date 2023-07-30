using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    [Authorize]
    public class EditProductController : Controller
    {
        private readonly IEditProductService _editProductService;
        private readonly IFileUploadService _fileUploadService;
        private readonly IWarehouseService _warehouseService;
        private readonly ILogger<IEditProductService> _logger;

        public EditProductController(IEditProductService editProductService, IFileUploadService fileUploadService,
        ILogger<IEditProductService> logger, IWarehouseService warehouseService)
        {
            _editProductService = editProductService;
            _fileUploadService = fileUploadService;
            _logger = logger;
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int ProductId)
        {
            Product? product = await _warehouseService.GetProductAsync(ProductId)!;

            if (product == null)
            {
                return View("_NotFound");
            }
            else
            {
                ProductViewModel productViewModel = new()
                {
                    Name = product.Name,
                    Priority = product.Priority,
                    Description = product.Description,
                    Price = product.Price,
                    Weight = product.Weight,
                    AmountAvailable = product.AmountAvailable,
                    CategoryId = product.CategoryId,
                    PhotoUrlAddress = product.PhotoUrlAddress
                };
                return View(productViewModel);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductId, ProductViewModel model)
        {
            Product? product = await _warehouseService.GetProductAsync(ProductId)!;

            if (product == null || ProductId != product.ProductId)
            {
                return View("_NotFound");
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            string? photoUrlAddress = product.PhotoUrlAddress;

            // If a new photo was uploaded.
            if (model.ProductImage != null)
            {
                // Use FileUploadService to upload the file.
                var uploadResult = await _fileUploadService.UploadFileAsync(model.ProductImage);
                if (uploadResult != null)
                {
                    photoUrlAddress = uploadResult;
                }
            }

            product = new Product
            {
                ProductId = model.ProductId,
                Priority = model.Priority,
                CategoryId = model.CategoryId,
                Name = model.Name,
                Price = model.Price,
                Weight = model.Weight,
                Description = model.Description,
                AmountAvailable = model.AmountAvailable,
                PhotoUrlAddress = photoUrlAddress
            };

            var (IsSuccess, Error) = await _editProductService.UpdateProductAsync(product);

            if (IsSuccess)
            {
                return RedirectToAction("Index", "Warehouse");
            }

            if (Error != null)
            {
                return HandleUpdateError(Error, product);
            }
            return View(product);
        }


        private IActionResult HandleUpdateError(Exception ex, Product product)
        {
            _logger.LogError(ex, "Wystąpił błąd podczas aktualizacji produktu. Spróbuj ponownie później.");
            ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas aktualizacji produktu. Spróbuj ponownie później.");
            return View(product);
        }

    }
}
