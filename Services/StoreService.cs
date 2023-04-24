using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Services
{
    public class StoreService : IStoreService
    {
        private readonly DbStoreContext _context;

        public StoreService(DbStoreContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            var products = _context.Products.ToList();

            return products;
        }
    }
}
