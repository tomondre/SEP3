using System.ComponentModel.DataAnnotations;

namespace GrpcFileGeneration.Models
{
    public class Customer
    {
        public int? Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,14}$",ErrorMessage =
            "The password must be between 8 (included) and 14 (included) characters, " +
            "contain at least one number" +
            "contain at least one upper case character" +
            "contain at least one lower case character")]
        public string Password { get; set; }
        [Required]
        public Address Address { get; set; }

        public string Token { set; get; }
        public Customer()
        {
            Address = new Address();
        }
    }
}