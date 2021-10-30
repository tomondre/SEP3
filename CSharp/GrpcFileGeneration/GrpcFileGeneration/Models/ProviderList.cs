using System.Collections.Generic;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class ProviderList : ILinkContainer
    {
        public IList<Provider> Providers { get; set; }
        public Dictionary<string, Link> Links { get; set; }


        public ProviderList()
        {
            Links = new Dictionary<string, Link>();
            Providers = new List<Provider>();
        }

        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }
    }
}