using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Networking.Provider;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Provider : User, ILinkContainer
    {
        public Dictionary<string, Link> Links { set; get; }
        
        // [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        // [Required]
        // [Range(10000000,99999999)]
        public int Cvr { get; set; }
        // [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        // [Required, MaxLength(500)]
        public string Description { get; set; }
        
        public bool IsApproved { set; get; }

        public Address Address { get; set; }


        public Provider()
        {
            Address = new Address();
        }

        public Provider(ProviderMessage message) : base(message.User)
        {
            CompanyName = message.CompanyName;
            Cvr = message.Cvr;
            Description = message.Description;
            PhoneNumber = message.PhoneNumber;
            IsApproved = message.IsApproved;
            Address = new Address(message.Address);
        }

        public ProviderMessage ToMessage()
        {
            return new ProviderMessage()
            {
                Address = Address.ToMessage(),
                Cvr = this.Cvr,
                Description = this.Description,
                CompanyName = this.CompanyName,
                IsApproved = this.IsApproved,
                PhoneNumber = this.PhoneNumber,
                User = base.ToMessage()
            };
        }
        public void AddLink(string id, Link link)
        {
            if (!Links.ContainsKey(id))
            {
                Links.Add(id, link);
            }
        }
        
    }
}