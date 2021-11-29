using Networking.Order;

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

        public ExperienceCartItem(OrderItemMessage item)
        {
            Experience = new Experience
            {
                Id = item.Id,
                Description = item.Description,
                Picture = item.Picture,
                Name = item.Name,
                Price = item.Price,
            };
            Quantity = item.Quantity;
        }

        public OrderItemMessage ToMessage()
        {
            return new OrderItemMessage
            {
                Description = Experience.Description,
                Name = Experience.Name,
                Picture = Experience.Picture,
                Price = Experience.Price,
                Quantity = Quantity
            };
        }
    }
}