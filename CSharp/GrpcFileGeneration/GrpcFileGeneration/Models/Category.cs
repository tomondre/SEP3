using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models
{
    public class Category : ILinkContainer
    {
        private Dictionary<string, Link> links;
        public int Id { set; get; }
        [Required(ErrorMessage = "Please add a category name")]
        
        public string CategoryName { get; set; }


        public Category()
        {
            Links = new Dictionary<string, Link>();
        }
        
        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }
        
        public Dictionary<string, Link> Links
        {
            get => links;
            set => links = value;
        }

        public override string ToString()
        {
            return $"{Id} {CategoryName}";
        }
    }
}