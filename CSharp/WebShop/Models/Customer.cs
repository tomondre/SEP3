using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RiskFirst.Hateoas.Models;

namespace WebShop.Models
{
    public class Customer : User, ILinkContainer
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        
        [ValidateComplexType]
        public Address Address { get; set; }

        public Dictionary<string, Link> Links { set; get; }

        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }

        public Customer()
        {
            Address = new Address();
            Links = new Dictionary<string, Link>();
        }
    }
}