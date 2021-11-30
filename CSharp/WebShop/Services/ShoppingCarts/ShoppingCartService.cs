using System.Linq;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Order;

namespace WebShop.Services.ShoppingCarts
{
    public class ShoppingCartService : IShoppingCartService
    {
        public GrpcFileGeneration.Models.Orders.ShoppingCart ShoppingCart { get; set; }

        public ShoppingCartService()
        {
            ShoppingCart = new GrpcFileGeneration.Models.Orders.ShoppingCart();
        }
        public void AddExperience(Experience experience, int quantity)
        {
            try
            {
                var experienceCartItem = ShoppingCart.ShoppingCartItems.First(e => e.Experience.Equals(experience));
                experienceCartItem.Quantity += quantity;
            }
            catch
            {
                ShoppingCart.ShoppingCartItems.Add(new ExperienceCartItem {Experience = experience, Quantity = quantity});
            }
        }
        
        public void RemoveExperienceItem(ExperienceCartItem experience)
        {
            ShoppingCart.ShoppingCartItems.Remove(experience);
        }
    }
}