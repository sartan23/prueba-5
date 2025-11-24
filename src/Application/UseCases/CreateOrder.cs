using Domain.Abstractions;
using Domain.Entities;
using Domain.Services;



namespace Application.UseCases
{
    public class CreateOrderUseCase
    {
        private readonly ILogger _logger;
        private readonly IOrderRepository _repo;

        public CreateOrderUseCase(ILogger logger, IOrderRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public Order Execute(string customer, string product, int qty, decimal price)
        {
            _logger.Log("CreateOrderUseCase starting");

            var order = OrderService.CreateOrder(customer, product, qty, price);

            _repo.SaveOrder(order);

            var total = order.CalculateTotalAndLog();
            _logger.Log($"Order total: {total}");

            return order;
        }
    }
}
