using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Provider : ILinkContainer
    {
        public Dictionary<string, Link> Links { set; get; }
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
        [Required, EmailAddress]
        public bool IsApproved { set; get; }
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,14}$",ErrorMessage =
            "The password must be between 8 (included) and 14 (included) characters, " +
            "contain at least one number" +
            "contain at least one upper case character" +
            "contain at least one lower case character")]
        public Address Address { get; set; }
        public string Password { get; set; }

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