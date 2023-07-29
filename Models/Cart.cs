
using System.ComponentModel.DataAnnotations.Schema;

namespace MiodOdStaniula.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        
        public int ClientId { get; set; }
        
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public int CartItemId { get; set; }
        
        public Product? Product { get; set; }
        
        public int Quantity { get; set; }
        
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}
