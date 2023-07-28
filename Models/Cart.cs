
namespace MiodOdStaniula.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } 

        // public decimal TotalPrice => Items.Sum(item => item.Product.Price * item.Quantity);

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }

    public class CartItem
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
