using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult ProductsList()
        {
            var productList = _storeService.GetAll();
            return View(productList);
        }
    }
}
