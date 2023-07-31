using MiodOdStaniula.Models;

namespace MiodOdStaniula.Services.Interfaces
{
    public interface ICartService
    {
        Task AddItemToCart(Guid cartId, int productId, int quantity);
    }
}
