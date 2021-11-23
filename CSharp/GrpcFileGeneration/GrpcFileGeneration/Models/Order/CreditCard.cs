namespace WebShop.Models
{
    public class CreditCard
    {
        //TODO create annotations for validation
        public string Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Cvv { get; set; }
    }
}