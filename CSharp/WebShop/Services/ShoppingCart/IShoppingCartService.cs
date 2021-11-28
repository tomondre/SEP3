using GrpcFileGeneration.Models;
using GrpcFileGeneration.Models.Order;

namespace WebShop.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        GrpcFileGeneration.Models.Order.ShoppingCart ShoppingCart { get;}
        void AddExperience(Experience experience, int quantity);
        void RemoveExperienceItem(ExperienceCartItem experience);
    }
}