using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Threading;
using Networking.Address;
using Networking.Experience;

namespace GrpcFileGeneration.Models
{
    public class Experience
    {
        public int Id { get;  set; }
        public string Picture { get; set; } = "";
        
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        public int Stock { get;  set; }
        
        [Required, MaxLength(500)]
        public string Description { get; set; }
        [Required]        
        public int ExperienceValidity { get; set; }

        public int CategoryId { get; set; }
        
        public  int ProviderId { get; set; }
        
        public Address Address { get; set; }

        public Experience()
        {
            Address = new Address();
        }

        public Experience(ExperienceMessage e)
        {
            Id = e.Id;
            Picture = e.Picture;
            Name = e.Name;
            Price = e.Price;
            Stock = e.Stock;
            Description = e.Description;
            ExperienceValidity = e.ExperienceValidity;
            CategoryId = e.CategoryId;
            ProviderId = e.ProviderId;
            Address = new Address(e.Address);
        }

        public ExperienceMessage ToMessage()
        {
            return new ExperienceMessage
            {
                Id = Id,
                Address = Address.ToMessage(),
                Description = Description,
                Name = Name,
                Price = Price,
                Picture = Picture,
                Stock = Stock,
                CategoryId = CategoryId,
                ExperienceValidity = ExperienceValidity,
                ProviderId = ProviderId
            };
        }
    }
}