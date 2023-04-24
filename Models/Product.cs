using System.ComponentModel.DataAnnotations;

namespace MiodOdStaniula.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Priorytetem określasz kolejność wyświetlania tego produktu")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "W jakiej kategorii jest ten produkt")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Podaj nazwę produktu")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Podaj cenę produktu")]
        public int Price { get; set; }

        
        public int Weight { get; set; }
        
        public string? Description { get; set; }

        public int AmountAvailable { get; set; }

    }
}
