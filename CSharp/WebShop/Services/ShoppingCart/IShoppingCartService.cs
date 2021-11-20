using System.Collections.Generic;
using GrpcFileGeneration.Models;
using WebShop.Models;

namespace WebShop.Data.ShoppingCart
{
    public interface IShoppingCartService
    {
        Models.ShoppingCart ShoppingCart { get;}
    }
}