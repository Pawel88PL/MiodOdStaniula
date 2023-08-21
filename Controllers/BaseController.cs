using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class BaseController : Controller
    {
        protected readonly DbStoreContext _context;
        protected readonly ICartService _cartService;
        protected readonly ICheckoutService _checkoutService;
        protected readonly ICustomerService _customerService;
        protected readonly ITotalCostService _totalCostService;

        public BaseController(
            DbStoreContext context,
            ICartService cartService,
            ICheckoutService checkoutService,
            ICustomerService customerService,
            ITotalCostService totalCostService)
        {
            _context = context;
            _cartService = cartService;
            _checkoutService = checkoutService;
            _customerService = customerService;
            _totalCostService = totalCostService;
        }

        protected async Task<CartViewModel> PrepareCartViewModel()
        {
            var cartIdStr = HttpContext.Session.GetString("CartId");
            var cartViewModel = new CartViewModel();

            if (!string.IsNullOrEmpty(cartIdStr))
            {
                var cartId = Guid.Parse(cartIdStr);
                var cart = await _cartService.GetCartAsync(cartId);
                var productCost = await _totalCostService.CalculateProductCostAsync(cartId);
                var shippingCost = await _totalCostService.CalculateShippingCostAsync(cartId);
                var totalCost = await _totalCostService.CalculateTotalAsync(cartId);

                cartViewModel = new CartViewModel
                {
                    CartItems = cart?.CartItems ?? new List<CartItem>(),
                    ProductCost = productCost,
                    ShippingCost = shippingCost,
                    TotalCost = totalCost
                };
            }
            return cartViewModel;
        }
    }
}