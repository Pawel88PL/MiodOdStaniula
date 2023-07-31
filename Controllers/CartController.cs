using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("{cartId}/items")]
        public async Task<IActionResult> AddItemToCart(Guid cartId, AddCartItemModel model)
        {
            try
            {
                await _cartService.AddItemToCart(cartId, model.ProductId, model.Quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the error here
                return BadRequest(ex.Message);
            }
        }
    }
}