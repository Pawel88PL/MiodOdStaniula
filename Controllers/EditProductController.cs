﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    [Authorize]
    public class EditProductController : Controller
    {
        private readonly DbStoreContext _context;
        private readonly IEditProductService _editProductService;
        private readonly IFileUploadService _fileUploadService;
        private readonly IWarehouseService _warehouseService;
        private readonly ILogger<IEditProductService> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditProductController
            (
                DbStoreContext context,
                IEditProductService editProductService,
                IFileUploadService fileUploadService,
                ILogger<IEditProductService> logger,
                IWarehouseService warehouseService,
                IWebHostEnvironment webHostEnvironment
            )
        {
            _context = context;
            _editProductService = editProductService;
            _fileUploadService = fileUploadService;
            _logger = logger;
            _warehouseService = warehouseService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product? product = await _warehouseService.GetProductAsync(id)!;

            if (product == null)
            {
                return View("_NotFound");
            }
            else
            {
                var productImages = new List<ProductImageInfo>();

                if (_context.ProductImages != null)
                {
                    productImages = await _context.ProductImages
                              .Where(pi => pi.ProductId == id)
                              .Select(pi => new ProductImageInfo
                              {
                                  ImageId = pi.ImageId,
                                  ImagePath = pi.ImagePath
                              })
                              .ToListAsync();
                }

                ProductViewModel productViewModel = new()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Priority = product.Priority,
                    Description = product.Description,
                    Price = product.Price,
                    Weight = product.Weight,
                    AmountAvailable = product.AmountAvailable,
                    CategoryId = product.CategoryId,
                    ProductImageInfos = productImages
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
            if (model.ProductImages != null && model.ProductImages.Any())
            {
                var imagePaths = await _fileUploadService.UploadFilesAsync(model.ProductImages);

                product.ProductImages = product.ProductImages ?? new List<ProductImage>();
                foreach (var path in imagePaths)
                {
                    product.ProductImages.Add(new ProductImage { ImagePath = path, ProductId = product.ProductId });
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
                return RedirectToAction("Details", "Products", new { id = product?.ProductId });
            }

            if (Error != null)
            {
                return HandleUpdateError(Error, product);
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int imageId, int ProductId)
        {
            Product? product = await _warehouseService.GetProductAsync(ProductId)!;

            if (_context.ProductImages != null)
            {
                var image = await _context.ProductImages.FindAsync(imageId);
                if (image == null || string.IsNullOrEmpty(image.ImagePath))
                {
                    return View("_NotFound");
                }

                var fileName = Path.GetFileName(image.ImagePath);
                if (string.IsNullOrEmpty(fileName))
                {
                    return View("_NotFound");
                }

                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                _context.ProductImages.Remove(image);
                await _context.SaveChangesAsync();

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                else
                {
                    return View("_NotFound");
                }
            }
            return RedirectToAction("Edit", "EditProduct", new { id = product?.ProductId });
        }

        private IActionResult HandleUpdateError(Exception ex, Product product)
        {
            _logger.LogError(ex, "Wystąpił błąd podczas aktualizacji produktu. Spróbuj ponownie później.");
            ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas aktualizacji produktu. Spróbuj ponownie później.");
            return View(product);
        }

    }
}
