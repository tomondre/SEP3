using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Provider : ILinkContainer
    {
        private Dictionary<string, Link> _links;
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [Range(10000000,99999999)]
        public int Cvr { get; set; }
        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        [Required, MaxLength(50)]
        public string Street { get; set; }
        [Required, MaxLength(5)]
        public string StreetNumber { get; set; }
        [Required]
        [Range(1000,9999)]
        public int PostCode { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

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