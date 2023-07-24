using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Services
{
    public class AddProductService: IAddProductService
    {

        private readonly DbStoreContext _dbStoreContext;

        public AddProductService(DbStoreContext dbStoreContext)
        {
            _dbStoreContext = dbStoreContext;
        }

        public async Task<Product> AddNewProductAsync(Product product)
        {
            _dbStoreContext.Add(product);
            await _dbStoreContext.SaveChangesAsync();
            return product;
        }
    }
}
