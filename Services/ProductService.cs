using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Services
{
    public class ProductService : IProductService
    {

        public List<Product> Sort(IEnumerable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case "category":
                    return products.OrderBy(p => p.CategoryId).ToList();
                case "name_asc":
                    return products.OrderBy(p => p.Name).ToList();
                case "price_asc":
                    return products.OrderBy(p => p.Price).ToList();
                case "price_desc":
                    return products.OrderByDescending(p => p.Price).ToList();
                case "date_asc":
                    return products.OrderBy(p => p.DateAdded).ToList();
                case "available-desc":
                    return products.OrderByDescending(p => p.AmountAvailable).ToList();
                case "popularity":
                    return products.OrderByDescending(p => p.Popularity).ToList();
                default:
                    return products.OrderBy(p => p.Priority).ToList();
            }
        }

        public List<Product> Filter(IEnumerable<Product> products, string filterCondition)
        {
            if (!string.IsNullOrEmpty(filterCondition))
            {
                if (products.Any(p => p.Category != null && p.Category.Name != null && p.Category.Name.Equals(filterCondition)))
                {
                    return products.Where(p => p.Category != null && p.Category.Name != null && p.Category.Name.Equals(filterCondition)).ToList();
                }
            }
            return products.ToList();
        }
    }
}
