using Domain.Entities;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Logging;
using System;


// Se agrega un namespace porque no se permite clases sin namespace definido.
namespace WebApi.useCases
{
    /// <summary>
    /// Caso de uso para crear una orden.
    /// </summary>
    public class CreateOrderUseCase
    {
        protected CreateOrderUseCase()
        {
        }
        // Mejora la claridad se entiende que no depende de un objeto.
        // Reduce uso innecesario de memoria.
        // Elimina advertencias de diseño Clean Code.
        public static Order Execute(string customer, string product, int qty, decimal price)
        {
            Logger.Log("CreateOrderUseCase starting");
            var order = OrderService.CreateTerribleOrder(customer, product, qty, price);

            var sql = "INSERT INTO Orders(Id, Customer, Product, Qty, Price) VALUES (" + order.Id + ", '" 
                + customer + "', '" + product + "', " + qty + ", " + price + ")";
            Logger.Try(() => BadDb.ExecuteNonQueryUnsafe(sql)); // swallow failures silently

            System.Threading.Thread.Sleep(1500);
            return order;
        }
    }
}


    
