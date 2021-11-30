using System.Collections.Generic;

namespace GrpcFileGeneration.Models.Orders
{
    public class OrderList
    {
        public IList<Order> Orders { get; set; }

        public OrderList()
        {
            Orders = new List<Order>();
        }
    }
}