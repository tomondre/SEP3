using System.ComponentModel.DataAnnotations;

namespace GrpcFileGeneration.Models
{
    public class Experience
    {
        public int Id { get;  set; }
        [Required]
        public string Picture { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        
        public Validity ExperienceValidity { get; set; }
        
        public Category ExperienceCategory { get; set; }
        public  Provider ExperienceProvider { get; set; }

        public Experience()
        {
            ExperienceValidity = Validity.ThreeMonths;
            ExperienceCategory = new Category();
            ExperienceProvider = new Provider();
        }

    }
}