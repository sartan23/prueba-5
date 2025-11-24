using System;
using System.Collections.Generic;

namespace Domain.Services
{
    using Domain.Entities;
    public static class OrderService
    {
        private static List<Order> LastOrders = new();

        public static IReadOnlyList<Order> GetLastOrders() => LastOrders;

        public static Order CreateOrder(string customerName, string productName, int quantity, decimal unitPrice)
        {
            var o = new Order
            {
                Id = new Random().Next(1, 9999999),
                CustomerName = customerName,
                ProductName = productName,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            LastOrders.Add(o);
            return o;
        }
    }
}