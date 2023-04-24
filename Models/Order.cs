using System.ComponentModel.DataAnnotations;

namespace MiodOdStaniula.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string? OrderNumber { get; set; }

        public string? OrderPrice { get; set; }
    }
}
