using System.Collections.Generic;

namespace GrpcFileGeneration.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int Cvr { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IList<Link> Links { get; set; }

        public Provider()
        {
            Links = new List<Link>();
        }
    }
}