using Microsoft.AspNetCore.Http;
using MiodOdStaniula.Models;

namespace MiodOdStaniula.Models
{
    public class ProductViewModel : Product
    {
        public IFormFile? ProductImage { get; set; }
    }
}
