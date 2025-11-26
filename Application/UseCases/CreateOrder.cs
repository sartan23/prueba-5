using System.Threading;
using System;
namespace Application.UseCases;

using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Logging;

public class CreateOrderUseCase
{
    private readonly OrderService _orderService;
    private readonly ILogger _logger;

    public CreateOrderUseCase(OrderService orderService, ILogger logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    public Order Execute(string customer, string product, int qty, decimal price)
    {
        _logger.Log("CreateOrderUseCase starting");

        var order = _orderService.CreateTerribleOrder(customer, product, qty, price);

        var sql = $"INSERT INTO Orders(Id, Customer, Product, Qty, Price) VALUES ({order.Id}, '{customer}', '{product}', {qty}, {price})";

        _logger.Try(() => BadDb.ExecuteNonQueryUnsafe(sql));

        Thread.Sleep(1500);

        return order;
    }
}
