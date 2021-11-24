using System.ComponentModel.DataAnnotations;

namespace GrpcFileGeneration.Models
{
    public class Customer : User
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public Address Address { get; set; }

        public Customer()
        {
            Address = new Address();
        }
    }
}