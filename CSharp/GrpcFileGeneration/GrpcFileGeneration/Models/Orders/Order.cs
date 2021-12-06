using System;
using System.Collections.Generic;
using GrpcFileGeneration.Models.Order;
using Networking.Order;
using RiskFirst.Hateoas.Models;

namespace GrpcFileGeneration.Models.Orders
{
    public class Order : ILinkContainer
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Comment { get; set; } = "";
        public string PaymentId { get; set; }
        public string Date { get; set; }

        public Order()
        {
            Links = new Dictionary<string, Link>();
            Customer = new();
            ShoppingCart = new();
            CreditCard = new();
        }

        public Order(OrderMessage order)
        {
            Links = new Dictionary<string, Link>();
            Comment = order.Comment;
            Customer = new Customer() {Id = order.CustomerId};
            Id = order.Id;
            ShoppingCart = new ShoppingCart();
            Date = order.Date;
            foreach (var orderItemMessage in order.Items)
            {
                ShoppingCart.ShoppingCartItems.Add(new ExperienceCartItem(orderItemMessage));
            }
        }

        public OrderMessage ToMessage()
        {
            OrderMessage message = new OrderMessage
            {
                CustomerId = Customer.Id,
                Comment = Comment,
                Total = ShoppingCart.OrderTotal
            };
            foreach (var item in ShoppingCart.ShoppingCartItems)
            {
                message.Items.Add(item.ToMessage());
            }
            return message;
        }

        public void RemoveCreditCardInformation()
        {
            CreditCard = new();
        }

        public void AddLink(string id, Link link)
        {
            if (!Links.ContainsKey(id))
            {
                Links.Add(id, link);
            }
        }

        public Dictionary<string, Link> Links { get; set; }
    }
}