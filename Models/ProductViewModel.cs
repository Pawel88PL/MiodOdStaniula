namespace MiodOdStaniula.Models
{
    public class ProductViewModel : Product
    {
        public new List<IFormFile> ProductImages { get; set; } = new List<IFormFile>();
        public List<string?>? ProductImagesURL { get; set; }

    }
}
