using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services;
using Moq;

namespace MiodOdStaniula.Tests
{
    public class CartServiceTests
    {
        private readonly CartService _cartService;
        private readonly Mock<DbSet<Cart>> _mockCarts;
        private readonly Mock<DbSet<Product>> _mockProducts;

        public CartServiceTests()
        {
            _mockCarts = new Mock<DbSet<Cart>>();
            _mockProducts = new Mock<DbSet<Product>>();

            var mockContext = new Mock<DbStoreContext>();
            mockContext.Setup(c => c.Carts).Returns(_mockCarts.Object);
            mockContext.Setup(c => c.Products).Returns(_mockProducts.Object);

            _cartService = new CartService(mockContext.Object);
        }

        [Fact]
        public async Task AddItemToCart_AddsNewItem_WhenCartIsEmpty()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var productId = 1;
            var quantity = 1;

            var cart = new Cart { CartId = cartId, CartItems = new List<CartItem>() };
            var product = new Product { ProductId = productId, Price = 100 };

            _mockCarts.Setup(m => m.FindAsync(It.IsAny<Guid>())).Returns(new ValueTask<Cart?>(cart));
            _mockProducts.Setup(m => m.FindAsync(It.IsAny<Guid>())).Returns(new ValueTask<Product?>(product));

            // Act
            await _cartService.AddItemToCart(cartId, productId, quantity);

            // Assert
            Assert.Single(cart.CartItems);
            Assert.Equal(productId, cart.CartItems.First().Product?.ProductId);
            Assert.Equal(quantity, cart.CartItems.First().Quantity);
        }
    }
}
