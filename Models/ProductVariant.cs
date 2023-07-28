using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiodOdStaniula.Models
{
    public class ProductVariant
    {
        [Key]
        public int VariantId { get; set; }
        
        [Required(ErrorMessage = "Podaj cenę produktu")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Podaj wagę produktu")]
        public int Weight { get; set; }

        public int AmountAvailable { get; set; }

        [StringLength(200, ErrorMessage = "URL zdjęcia nie może przekraczać 200 znaków.")]
        public string? PhotoUrlAddress { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
