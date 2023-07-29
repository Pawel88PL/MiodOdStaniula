using MiodOdStaniula.Models;

namespace MiodOdStaniula.Services.Interfaces
{
    public interface ICartService
    {
        Task AddItemToCart(int cartId, int productId, int quantity);
    }
}
