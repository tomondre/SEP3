using Google.Protobuf.WellKnownTypes;
using GrpcFileGeneration.Models;

namespace WebShop.Models
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

        public void AddOneQuantity()
        {
            Quantity++;
        }

        public void RemoveOneQuantity()
        {
            if (Quantity > 0)
            {
                Quantity--;
            }
        }
    }
}