using System.Collections.Generic;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Provider : ILinkContainer
    {
        private Dictionary<string, Link> _links;
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int Cvr { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }

        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }

        public Dictionary<string, Link> Links
        {
            get => _links;
            set => _links = value;
        }

        public Provider()
        {
            Links = new Dictionary<string, Link>();
        }
    }
}