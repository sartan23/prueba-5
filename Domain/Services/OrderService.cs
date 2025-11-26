using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System;

namespace Domain.Services
{
    public class OrderService
    {
        private readonly ILogger _logger;
        public OrderService(ILogger logger)
        {
            _logger = logger;
        }

        public List<Order> LastOrders { get; } = new();

        public Order CreateTerribleOrder(string customer, string product, int qty, decimal price)
        {
            var o = new Order
            {
                Id = new Random().Next(1, 9999999),
                CustomerName = customer,
                ProductName = product,
                Quantity = qty,
                UnitPrice = price
            };

            LastOrders.Add(o);
            _logger.Log($"Created order {o.Id} for {customer}");
            return o;
        }
        public Order ProcessOrder(Order order)
        {
            var total = order.CalculateTotal();
            _logger.Log($"Total (maybe): {total}");
            return order;
        }
    }
}
