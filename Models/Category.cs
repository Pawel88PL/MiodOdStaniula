using System.ComponentModel.DataAnnotations;

namespace MiodOdStaniula.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę kategorii")]
        public string? Name { get; set; }
        
        public string? Description { get; set; }
    }
}
