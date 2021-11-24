using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Provider : User, ILinkContainer
    {
        public Dictionary<string, Link> Links { set; get; }
        
        [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [Range(10000000,99999999)]
        public int Cvr { get; set; }
        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        
        public bool IsApproved { set; get; }

        public Address Address { get; set; }


        public Provider()
        {
            Address = new Address();
        }

        public void AddLink(string id, Link link)
        {
            Links = new Dictionary<string, Link>();
        }
        
    }
}