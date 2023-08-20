using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Tunel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder()
        {
            var sessionId = new Guid(HttpContext.Session.Id);

            var order = await _checkoutService.CreateOrderAsync(sessionId);

            if (order == null)
            {
                // Obsłuż sytuację, gdy nie można utworzyć zamówienia
                return View("Error"); // lub inny widok/komunikat błędu
            }

            return RedirectToAction("OrderConfirmation", new { orderId = order.OrderId });
        }

    }
}