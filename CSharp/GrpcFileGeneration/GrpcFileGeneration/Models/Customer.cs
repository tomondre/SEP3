using System.ComponentModel.DataAnnotations;
using Networking.Customer;

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

        public Customer(CustomerMessage message) : base(message.UserMessage)
        {
            Address = new Address(message.Address);
            FirstName = message.FirstName;
            LastName = message.LastName;
            PhoneNumber = message.PhoneNumber;
        }

        public CustomerMessage ToMessage()
        {
            return new CustomerMessage()
            {
                Address = Address.ToMessage(),
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                UserMessage = base.ToMessage()
            };
        }
    }
}