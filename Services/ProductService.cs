using MiodOdStaniula.Models;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Services
{
    public class ProductService: IProductService
    {

        public List<Product> Sort(IEnumerable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name_asc":
                    return products.OrderBy(p => p.Name).ToList();
                case "price_asc":
                    return products.OrderBy(p => p.Variants?.Min(v => v.Price)).ToList();
                case "price_desc":
                    return products.OrderByDescending(p => p.Variants?.Max(v => v.Price)).ToList();
                case "date_asc":
                    return products.OrderBy(p => p.DateAdded).ToList();
                case "popularity":
                    return products.OrderByDescending(p => p.Popularity).ToList();
                case "priority":
                    return products.OrderBy(p => p.Priority).ToList();
                default:
                    return products.OrderBy(p => p.Priority).ToList();
            }
        }

        public List<Product> Filter(IEnumerable<Product> products, string filterCondition)
        {
            if (!string.IsNullOrEmpty(filterCondition))
            {
                return products.Where(p => p.Category.Name.Equals(filterCondition)).ToList();
            }
            return products.ToList();
        }

    }
}
