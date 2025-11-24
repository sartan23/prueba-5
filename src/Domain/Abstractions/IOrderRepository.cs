using Domain.Entities;



namespace Domain.Abstractions
{
    public interface IOrderRepository
    {
        void SaveOrder(Order order);
    }
}
