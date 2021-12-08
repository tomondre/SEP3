using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Orders
{
    public class CreditCard
    {
        [Required]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Card number should be a 16 digit number")]
        public string Number { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Month is a two digit number")]
        public int Month { get; set; }

        [Required]
        [Range(21, 30, ErrorMessage = "Please add a valid expiry year")]
        public int Year { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "Cvv should be a three digit number")]
        public string Cvv { get; set; }
    }
}