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
        public async Task<IActionResult> Index()
        {
            var cartIdStr = HttpContext.Session.GetString("CartId");

            if (string.IsNullOrEmpty(cartIdStr))
            {
                // Jeżeli nie ma koszyka w sesji, zwróć widok z pustym koszykiem
                return View(new List<CartItem>());
            }

            var cartId = Guid.Parse(cartIdStr);
            var cart = await _cartService.GetCartAsync(cartId);

            return View(cart?.CartItems ?? new List<CartItem>());
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


        [HttpPost]
        public async Task<IActionResult> AddItemToCart(AddCartItemModel model)
        {
            try
            {
                var cartIdStr = HttpContext.Session.GetString("CartId");

                if (string.IsNullOrEmpty(cartIdStr))
                {
                    var newCart = new ShopingCart();
                    if (_context.ShopingCarts != null)
                    {
                        _context.ShopingCarts.Add(newCart);
                        await _context.SaveChangesAsync();

                        cartIdStr = newCart.ShopingCartId.ToString();

                        HttpContext.Session.SetString("CartId", cartIdStr);
                    }
                }

                if (cartIdStr != null)
                {
                    var cartId = Guid.Parse(cartIdStr);

                    await _cartService.AddItemToCart(cartId, model.ProductId, model.Quantity);

                    if (_context.Products != null)
                    {
                        var product = await _context.Products.FindAsync(model.ProductId);
                        return Json(new
                        {
                            success = true,
                            product = new
                            {
                                name = product?.Name,
                                image = product?.PhotoUrlAddress,
                                weight = product?.Weight,
                                price = product?.Price,
                            }
                        });

                    }

                    return Json(new { success = false });
                }
                return View("_NotFound");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Pojawił się błądd podczas dodawania produktu do koszyka.\nSpróbuj ponownie p�niej.";
                return RedirectToAction("Index", "Products");
            }
        }
    }
}
