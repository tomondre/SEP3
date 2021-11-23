using Customer = GrpcFileGeneration.Models.Customer;

namespace WebShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Comment { get; set; }
        public string PaymentId { get; set; }

        public Order()
        {
            Customer = new();
            ShoppingCart = new();
            CreditCard = new();
        }

        public void RemoveCreditCardInformation()
        {
            CreditCard = new();
        }
    }
}