namespace GrpcFileGeneration.Models
{
    public class Customer
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }

        public Customer()
        {
            Address = new Address();
        }
    }
}