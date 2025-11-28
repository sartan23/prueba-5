using System;
using Domain.Entities;
using Infrastructure.Logging;

namespace Domain.Services;

/// <summary>
/// Servicio de dominio responsable de la creación y validación de órdenes.
/// Antes la clase tenía lógica confusa y nombres poco descriptivos.
/// Ahora se valida la entrada y se registran mensajes claros a través del logger.
/// </summary>
public static class OrderService
{
    public static Order CreateOrder(string customer, string product, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(customer))
        {
            throw new ArgumentException("Customer name is required.", nameof(customer));
        }

        if (string.IsNullOrWhiteSpace(product))
        {
            throw new ArgumentException("Product name is required.", nameof(product));
        }

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        }

        if (unitPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price must be greater than zero.");
        }

        var order = new Order
        {
            CustomerName = customer,
            ProductName = product,
            Quantity = quantity,
            UnitPrice = unitPrice,
        };

        Logger.LogInformation($"Order created for customer '{customer}' with product '{product}', qty {quantity}, unit price {unitPrice}.");

        return order;
    }
}
