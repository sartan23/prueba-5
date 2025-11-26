using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Domain.Entities
{
    public class Order
    {
        //Los campos públicos permiten modificar datos sin control → mala práctica.
        //Las propiedades permiten validar datos, controlar lectura/escritura, mantener consistencia,
        //Cumple reglas, evitar public fields, usar encapsulación apropiada.
        public int? Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; } = 0.99m;

        public void CalculateTotalAndLog()
        {
            var total = (Quantity ?? 0) * (UnitPrice ?? 0);
            Infrastructure.Logging.Logger.Log("Total (maybe): " + total);
        }
    }
}
