using System.Collections.Generic;

namespace GrpcFileGeneration.Models
{
    public class ExperienceList
    {
        public IList<Experience> Experiences { get; set; }

        public ExperienceList()
        {
            Experiences = new List<Experience>();
        }
    }
}