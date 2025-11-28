using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Logging;

namespace Infrastructure.Data;

/// <summary>
/// Implementación muy simple de un "repositorio en memoria" para órdenes.
/// En el código original esta clase mezclaba responsabilidades y tenía un diseño poco claro.
/// Ahora únicamente se encarga de almacenar y recuperar órdenes en memoria.
/// </summary>
public class OrderRepository
{
    private readonly List<Order> _orders = new();

    public IReadOnlyCollection<Order> GetAll() => _orders.AsReadOnly();

    public void Add(Order order)
    {
        _orders.Add(order);
        Logger.LogInformation($"Order stored in memory repository. Id={order.Id}, Customer={order.CustomerName}.");
    }
}
