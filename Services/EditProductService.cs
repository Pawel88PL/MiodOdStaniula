using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Services
{
    public class EditProductService : IEditProductService
    {
        private readonly DbStoreContext _context;
        private readonly ILogger<EditProductService> _logger;

        public EditProductService(DbStoreContext context, ILogger<EditProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, Exception? Error)> UpdateProductAsync(Product product)
        {
            try
            {
                var productInDb = await _context.Products.FindAsync(product.ProductId);
                if (productInDb != null)
                {
                    productInDb.Priority = product.Priority;
                    productInDb.Name = product.Name;
                    //productInDb.Price = product.Price;
                    //productInDb.Weight = product.Weight;
                    productInDb.Description = product.Description;
                    //productInDb.AmountAvailable = product.AmountAvailable;
                    //productInDb.PhotoUrlAddress = product.PhotoUrlAddress;
                    productInDb.CategoryId = product.CategoryId;

                    await _context.SaveChangesAsync();
                    return (true, null);

                }
                else
                {
                    
                    return (false, new InvalidOperationException($"Nie znaleziono produktu o ID: {product.ProductId}"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Wystąpił błąd podczas aktualizacji danych pacjenta o Id: {Id}", product.ProductId);
                return (false, ex);
            }
        }
    }
}
