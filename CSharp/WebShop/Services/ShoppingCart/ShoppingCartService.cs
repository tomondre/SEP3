using System.Collections.Generic;
using System.Linq;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Order;
using WebShop.Services.ShoppingCart;

namespace WebShop.Models
{
    public class ShoppingCartService : IShoppingCartService
    {
        public ShoppingCart ShoppingCart { get; set; }

        public ShoppingCartService()
        {
            ShoppingCart = new ShoppingCart();
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