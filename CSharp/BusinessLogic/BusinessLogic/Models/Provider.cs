namespace ClientServer.Models
{
    public class Provider
    {
        private string CompanyName { get; set; }
        private int Cvr { get; set; }
        private string PhoneNumber { get; set; }
        private string Description { get; set; }
        private Address Address { get; set; }
    }
}