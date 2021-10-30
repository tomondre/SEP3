using System.Collections.Generic;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class HandShake : ILinkContainer
    {
        public Dictionary<string, Link> Links { get; set; }

        public HandShake()
        {
            Links = new Dictionary<string, Link>();
        }
        
        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }
    }
}