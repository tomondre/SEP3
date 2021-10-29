using System.Collections.Generic;

namespace GrpcFileGeneration.Models
{
    public class ProviderList
    {
        public IList<Provider> Providers { get; set; }
        public IList<Link> Links { get; set; }

        public ProviderList()
        {
            Links = new List<Link>();
            Providers = new List<Provider>();
        }

    }
}