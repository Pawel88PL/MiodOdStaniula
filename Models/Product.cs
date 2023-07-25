using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace MiodOdStaniula.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Priorytetem określasz kolejność wyświetlania produktu na stronie")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "Podaj nazwę produktu")]
        [StringLength(100, ErrorMessage = "Nazwa produktu nie może przekraczać 100 znaków.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Podaj cenę produktu")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Weight { get; set; }

        [StringLength(2000, ErrorMessage = "Opis produktu nie może przekraczać 2000 znaków.")]
        public string? Description { get; set; }

        public int AmountAvailable { get; set; }

        [StringLength(200, ErrorMessage = "URL zdjęcia nie może przekraczać 200 znaków.")]
        public string? PhotoUrlAddress { get; set; }

        public int? Popularity { get; set; }

        public DateTime DateAdded { get; set; }



        //Foregin keys
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
