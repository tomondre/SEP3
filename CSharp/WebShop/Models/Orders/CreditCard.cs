using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Orders
{
    public class CreditCard
    {
        public string Number { get; set; }

        [Range(2, 2, ErrorMessage = "Month is a two digit number")]
        public int Month { get; set; }

        [Range(2, 2, ErrorMessage = "Year is a two digit number")]
        public int Year { get; set; }
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "Month should be two digit number")]
        public string Cvv { get; set; }
    }
}