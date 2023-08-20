using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DbStoreContext _context;
        private readonly ICartService _cartService;
        private readonly ICheckoutService _checkoutService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<ICheckoutService> _logger;
        private readonly ITotalCostService _totalCostService;


        public CheckoutController(
            DbStoreContext context,
            ICartService cartService,
            ICheckoutService checkoutService,
            ICustomerService customerService,
            ILogger<ICheckoutService> logger,
            ITotalCostService totalCostService)
        {
            _cartService = cartService;
            _checkoutService = checkoutService;
            _customerService = customerService;
            _context = context;
            _logger = logger;
            _totalCostService = totalCostService;
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

        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Nie udało się dodać nowego klienta");
                return View(customer);
            }

            await _customerService.AddNewCustomer(customer);
            return RedirectToAction("Index", "Checkout");
        }


        [HttpGet]
        public IActionResult OrderConfirmation(int id)
        {
            if (_context.Orders != null)
            {
                var order = _context.Orders.Find(id);
                return View(order);
            }
            return View("_NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Checkout/PlaceOrderAsync")]
        public async Task<IActionResult> PlaceOrderAsync()
        {
            var sessionId = new Guid(HttpContext.Session.Id);

            var order = await _checkoutService.CreateOrderAsync(sessionId);

            if (order == null)
            {
                _logger.LogError("Nie udało się złożyć zamówienia");
                return View("_NotFound");
            }

            return RedirectToAction("OrderConfirmation", new { orderId = order.OrderId });
        }

    }
}