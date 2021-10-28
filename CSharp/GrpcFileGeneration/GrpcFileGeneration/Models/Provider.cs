namespace GrpcFileGeneration.Models
{
    public class Provider
    {
        public string CompanyName { get; set; }
        public int Cvr { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
    }
}