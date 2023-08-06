using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Services
{
    public class CartService : ICartService
    {
        private readonly DbStoreContext _context;

        public CartService(DbStoreContext context)
        {
            _context = context;
        }


        public async Task<ShopingCart?> GetCartAsync(Guid cartId)
        {
            if (_context.ShopingCarts != null)
            {
                var cart = await _context.ShopingCarts
                    .Include(p => p.CartItems)
                    .ThenInclude(c => c.Product)
                    .FirstOrDefaultAsync(p => p.ShopingCartId == cartId);

                return cart;
            }
            return null;
        }


        public async Task AddItemToCart(Guid cartId, int productId, int quantity)
        {
            if (_context.ShopingCarts != null)
            {

                var cart = await _context.ShopingCarts
                    .Include(c => c.CartItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefaultAsync(p => p.ShopingCartId == cartId);

                if (cart != null)
                {
                    if (_context.Products != null)
                    {
                        var product = await _context.Products
                            .FirstOrDefaultAsync(p => p.ProductId == productId);

                        if (product != null)
                        {
                            var cartItem = cart.CartItems
                                .FirstOrDefault(i => i.Product?.ProductId == productId);

                            if (cartItem != null)
                            {
                                // If the item is already in the cart, increase the quantity
                                cartItem.Quantity += quantity;
                            }
                            else
                            {
                                // If the item is not in the cart, add a new cart item
                                cart.CartItems.Add(new CartItem
                                {
                                    ProductId = product.ProductId,
                                    Product = product,
                                    Quantity = quantity,
                                    Price = product.Price,
                                });
                            }

                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            throw new Exception("Product not found");
                        }
                    }
                }
                else
                {
                    throw new Exception("Cart not found");
                }
            }
        }


        public async Task<int> GetCartItemCount(Guid cartId)
        {
            if (_context.ShopingCarts != null)
            {
                var cart = await _context.ShopingCarts
                    .Include(c => c.CartItems)
                    .FirstOrDefaultAsync(c => c.ShopingCartId == cartId);

                if (cart != null)
                {
                    return cart.CartItems.Sum(item => item.Quantity);
                }
            }
            return 0;
        }

    }
}