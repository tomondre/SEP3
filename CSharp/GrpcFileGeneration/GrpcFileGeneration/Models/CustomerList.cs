using System.Collections.Generic;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class CustomerList : ILinkContainer
    {
        public Dictionary<string, Link> Links { get; set; }
        public IList<Customer> Customers { set; get; }

        public CustomerList()
        {
            Links = new Dictionary<string, Link>();
            Customers = new List<Customer>();
        }
        
        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }

    }
}