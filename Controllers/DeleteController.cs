using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class DeleteController : Controller
    {
        private readonly IDeleteService _deleteService;
        private readonly IWarehouseService _warehouseService;

        public DeleteController(IDeleteService deleteService, IWarehouseService warehouseService)
        {
            _deleteService = deleteService;
            _warehouseService = warehouseService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductAsync(int ProductId)
        {
            var result = await _deleteService.DeleteProductAsync(ProductId);
            if (!result)
            {
                return View("_NotFound");
            }

            return RedirectToAction("Index", "Warehouse");
        }

    }
}