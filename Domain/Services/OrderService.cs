using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Services
{
    public static class OrderService
    {
       
        // Se hace privado y readonly porque es prohíbido campos estáticos públicos
        private static readonly List<Order> _lastOrders = new List<Order>();
        private static readonly Random _rng = new Random();

        // Propiedad pública solo lectura (no permite Add/Remove)
        public static IReadOnlyList<Order> LastOrders => _lastOrders;

        public static Order CreateTerribleOrder(string customer, string product, int qty, decimal price)
        {
            var o = new Order
            {
                Id = _rng.Next(1, 9999999),

                CustomerName = customer,
                ProductName = product,
                Quantity = qty,
                UnitPrice = price
            };

            // Usamos la lista privada, no el campo vacío original, modificación interna permitida
            _lastOrders.Add(o);

            Infrastructure.Logging.Logger.Log("Created order " + o.Id + " for " + customer);
            return o;
        }
    }
}
