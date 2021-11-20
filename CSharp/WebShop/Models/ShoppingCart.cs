using System.Collections.Generic;

namespace WebShop.Models
{
    public class ShoppingCart
    {
        public IList<ExperienceCartItem> ShoppingCartItems { get; set; }
        public int Tax { get; }
        public ShoppingCart()
        {
            ShoppingCartItems = new List<ExperienceCartItem>();
            Tax = 25;
        }

        public double OrderTotal
        {
            get
            {
                double total = 0;
                foreach (var item in ShoppingCartItems)
                {
                    total += item.TotalPrice;
                }

                return total;
            }
        }

        public double TaxAmount => (double) Tax / 100 * OrderTotal;
    }
}