namespace GrpcFileGeneration.Models.Order
{
    public class ExperienceCartItem
    {
        public Experience Experience { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice => Quantity * Experience.Price;

        public ExperienceCartItem()
        {
            Experience = new Experience();
        }
    }
}