using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiodOdStaniula;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    [Authorize]
    public class EditProductController : Controller
    {
        private readonly IEditProductService _editProductService;
        private readonly IWarehouseService _warehouseService;
        private readonly ILogger<IEditProductService> _logger;

        public EditProductController(IEditProductService editProductService, ILogger<IEditProductService> logger, IWarehouseService warehouseService)
        {
            _editProductService = editProductService;
            _logger = logger;
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int ProductId)
        {
            var product = await _warehouseService.GetProductAsync(ProductId);

            if (product == null)
            {
                return View("_NotFound");
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductId,
        [Bind("ProductId,Priority,CategoryId,Name,Price,Weight,Description,AmountAvailable,PhotoUrlAddress")] Product product)
        {
            if (ProductId != product.ProductId)
            {
                return View("_NotFound");
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var result = await _editProductService.UpdateProductAsync(product);

            if (result.IsSuccess)
            {
                return RedirectToAction("Details", "Store", new { ProductId });
            }

            if (result.Error != null)
            {
                return HandleUpdateError(result.Error, product);
            }
            return View(product);
        }


        private IActionResult HandleUpdateError(Exception ex, Product product)
        {
            _logger.LogError(ex, $"Wystąpił błąd podczas aktualizacji danych produktu o ID: {product.ProductId}", product.ProductId);
            ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas aktualizacji produktu. Spróbuj ponownie później.");
            return View(product);
        }

    }
}
