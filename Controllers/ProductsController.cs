using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiodOdStaniula.Models;
using MiodOdStaniula.Services;
using MiodOdStaniula.Services.Interfaces;

namespace MiodOdStaniula.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DbStoreContext _context;
        private readonly IWarehouseService _warehouseService;
        private readonly IProductService _productService;

        public ProductsController(DbStoreContext context, IWarehouseService warehouseService,
            IProductService productService)
        {
            _context = context;
            _warehouseService = warehouseService;
            _productService = productService;
        }

        private List<ProductViewModel> ConvertToViewModel(IEnumerable<Product> products)
        {
            
            return products.Select(product => new ProductViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Weight = product.Weight,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Priority = product.Priority,
                AmountAvailable = product.AmountAvailable,
                PhotoUrlAddress = product.PhotoUrlAddress,
                ProductImageInfos = product.ProductImages?.Select(pi => new ProductImageInfo
                {
                    ImageId = pi.ImageId,
                    ImagePath = pi.ImagePath
                }).ToList() ?? new List<ProductImageInfo>()

            }).ToList();
        }


        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string filterCondition)
        {
            var products = await GetSortedAndFilteredProducts(sortOrder, filterCondition);
            var viewModel = ConvertToViewModel(products);
            ViewBag.FilterCondition = string.IsNullOrEmpty(filterCondition) ? "Wszystkie produkty" : filterCondition;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Product? product = await _warehouseService.GetProductAsync(id)!;
            var cartId = HttpContext.Session.GetString("CartId");

            ViewData["CartId"] = cartId;

            if (product == null)
            {
                return View("_NotFound");
            }
            else
            {
                var productImages = new List<ProductImageInfo>();

                if (_context.ProductImages != null)
                {
                    productImages = await _context.ProductImages
                              .Where(pi => pi.ProductId == id)
                              .Select(pi => new ProductImageInfo
                              {
                                  ImageId = pi.ImageId,
                                  ImagePath = pi.ImagePath
                              })
                              .ToListAsync();
                }

                ProductViewModel productViewModel = new()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Priority = product.Priority,
                    Description = product.Description,
                    Price = product.Price,
                    Weight = product.Weight,
                    AmountAvailable = product.AmountAvailable,
                    CategoryId = product.CategoryId,
                    ProductImageInfos = productImages
                };
                return View(productViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string sortOrder, string filterCondition)
        {
            var products = await GetSortedAndFilteredProducts(sortOrder, filterCondition);
            ViewBag.FilterCondition = filterCondition;

            return PartialView("_ProductList", products);
        }

        private async Task<IEnumerable<Product>> GetSortedAndFilteredProducts(string sortOrder, string filterCondition)
        {
            var products = await _warehouseService.GetAllProductsAsync();
            products = _productService.Sort(products, sortOrder);
            products = _productService.Filter(products, filterCondition);
            return products;
        }
    }
}
