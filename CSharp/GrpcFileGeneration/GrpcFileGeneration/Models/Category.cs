using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Networking.Address;
using Networking.Category;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Category : ILinkContainer
    {
        public Dictionary<string, Link> Links { set; get; }
        public int Id { set; get; }
        // [Required(ErrorMessage = "Please add a category name")]
        
        public string CategoryName { get; set; }


        public Category()
        {
            Links = new Dictionary<string, Link>();
        }
        
        public Category(CategoryMessage m)
        {
            Links = new Dictionary<string, Link>();
            Id = m.Id;
            CategoryName = m.CategoryName;
        }
        public void AddLink(string id, Link link)
        {
            if (!Links.ContainsKey(id))
            {
                Links.Add(id, link);
            }
        }

        public CategoryMessage ToMessage()
        {
            return new CategoryMessage()
            {
                Id = Id,
                CategoryName = CategoryName
            };
        }

        public override string ToString()
        {
            return $"{Id} {CategoryName}";
        }
    }
}