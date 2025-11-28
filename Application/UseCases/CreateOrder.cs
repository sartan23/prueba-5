using Domain.Entities;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Logging;

namespace Application.UseCases;

/// <summary>
/// Caso de uso responsable de orquestar la creación de una orden
/// y su persistencia en el repositorio. Se separa de la capa Web
/// para cumplir con la arquitectura limpia.
/// </summary>
public class CreateOrderUseCase
{
    private readonly OrderRepository _repository;

    public CreateOrderUseCase(OrderRepository repository)
    {
        _repository = repository;
    }

    public Order Execute(string customer, string product, int quantity, decimal unitPrice)
    {
        Logger.LogInformation("CreateOrderUseCase starting");

        var order = OrderService.CreateOrder(customer, product, quantity, unitPrice);

        _repository.Add(order);

        Logger.LogInformation("CreateOrderUseCase finished");

        return order;
    }
}
