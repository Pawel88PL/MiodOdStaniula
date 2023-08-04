using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;
using System;

namespace MiodOdStaniula.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly DbStoreContext _context;

        public CartController(ICartService cartService, DbStoreContext context)
        {
            _cartService = cartService;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index(Guid ShopingCartId)
        {
            var cart = await _cartService.GetCartAsync(ShopingCartId);
            return View(cart);
        }


        [HttpGet]
        public async Task<IActionResult> GetCartItemCount()
        {
            var cartIdStr = HttpContext.Session.GetString("CartId");
            int itemCount = 0;

            if (!string.IsNullOrEmpty(cartIdStr))
            {
                var cartId = Guid.Parse(cartIdStr);
                itemCount = await _cartService.GetCartItemCount(cartId);
            }

            return Ok(itemCount);
        }


        [HttpPost("items")]
        public async Task<IActionResult> AddItemToCart(AddCartItemModel model)
        {
            try
            {
                var cartIdStr = HttpContext.Session.GetString("CartId");

                // Je�eli koszyka jeszcze nie ma, utw�rz nowy
                if (string.IsNullOrEmpty(cartIdStr))
                {
                    var newCart = new ShopingCart();
                    if (_context.ShopingCarts != null)
                    {
                        _context.ShopingCarts.Add(newCart);
                        await _context.SaveChangesAsync();

                        cartIdStr = newCart.ShopingCartId.ToString();

                        // Zapisz identyfikator koszyka w sesji
                        HttpContext.Session.SetString("CartId", cartIdStr);
                    }
                }

                if (cartIdStr != null)
                {
                    var cartId = Guid.Parse(cartIdStr);

                    await _cartService.AddItemToCart(cartId, model.ProductId, model.Quantity);
                    return RedirectToAction("Index", "Products");
                }
                return View("_NotFound");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Pojawi� si� b��d podczas dodawania produktu do koszyka.\nSpr�buj ponownie p�niej.";
                return RedirectToAction("Index", "Products");
            }
        }
    }
}
