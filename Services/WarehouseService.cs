using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Services
{
    public class WarehouseService: IWarehouseService
    {
        private readonly DbStoreContext _context;
        private readonly ILogger<WarehouseService> _logger;

        public WarehouseService(DbStoreContext context, ILogger<WarehouseService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product?> GetProductAsync(int ProductId)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Variants)
                .FirstOrDefaultAsync(p => p.ProductId == ProductId);

            if (product == null)
            {
                _logger.LogError($"Nie znaleziono produktu o ID: {ProductId}", ProductId);
            }

            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include (p => p.Variants)
                .ToListAsync();
            
            return products;
        }
    }
}
