using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MiodOdStaniula.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Priorytetem określasz kolejność wyświetlania tego produktu")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "W jakiej kategorii jest ten produkt")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Podaj nazwę produktu")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Podaj cenę produktu")]
        public decimal Price { get; set; }
                
        public decimal Weight { get; set; }
        
        public string? Description { get; set; }

        public int AmountAvailable { get; set; }

        public string? Photo { get; set; }
    }
}
