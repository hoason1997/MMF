namespace MFF.Infrastructure.Models
{
    public class CartModel
    {
        public int Quantity { set; get; }
        public ProductItemModel Product { set; get; }
    }
    public class AddCartModel
    {
        public int Quantity { set; get; }
        public ProductItemModel Product { set; get; }
    }
}
