using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly CreateOrderUseCase _createOrder;

    public OrdersController(CreateOrderUseCase createOrder)
    {
        _createOrder = createOrder;
    }

    [HttpPost]
    public ActionResult<Order> Create(CreateOrder request)
    {
        var order = _createOrder.Execute(
            request.CustomerName,
            request.ProductName,
            request.Quantity,
            request.UnitPrice
        );

        return Ok(order);
    }

    // Endpoint de prueba para verificar que la API funciona
    [HttpGet("ping")]
    public ActionResult<string> Ping()
    {
        return Ok("API is running!");
    }
}

public record CreateOrder(
    string CustomerName,
    string ProductName,
    int Quantity,
    decimal UnitPrice
);
