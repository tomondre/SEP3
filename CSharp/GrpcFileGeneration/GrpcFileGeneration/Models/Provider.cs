#nullable enable
using System.Collections.Generic;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Provider : ILinkContainer
    {
        public Dictionary<string, Link>? Links { get; set; }
        public int? Id { get; set; }
        public string CompanyName { get; set; }
        public int? Cvr { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }

        public bool? IsApproved { get; set; }

        public Provider()
        {
        }

        public void AddLink(string id, Link link)
        {

            Links = new Dictionary<string, Link>();
        }
    }
}