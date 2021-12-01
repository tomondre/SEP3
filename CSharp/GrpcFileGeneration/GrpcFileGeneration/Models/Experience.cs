using System.ComponentModel.DataAnnotations;

namespace GrpcFileGeneration.Models
{
    public class Experience
    {
        public int Id { get;  set; }
        // [Required]
        public string Picture { get; set; }
        // [Required, MaxLength(50)]
        public string Name { get; set; }
        // [Required]
        public double Price { get; set; }
        // [Required]
        public int Stock { get;  set; }
        // [Required, MaxLength(500)]
        
        public string Description { get; set; }
        
        // [Required, MaxLength(50)]
        public int ExperienceValidity { get; set; }
        
        public Category ExperienceCategory { get; set; }
        
        public  Provider ExperienceProvider { get; set; }
        
        public Address Address { get; set; }

        public Experience()
        {
            ExperienceCategory = new Category();
            ExperienceProvider = new Provider();
            Address = new Address();
        }

    }
}