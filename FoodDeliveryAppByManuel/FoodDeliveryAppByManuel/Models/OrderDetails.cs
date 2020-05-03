namespace FoodDeliveryAppByManuel.Models
{
    public class OrderDetails
    {
        public int id { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
        public double totalAmount { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }
    }
}
