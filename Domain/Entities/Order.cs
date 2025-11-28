using System;

namespace Domain.Entities;

/// <summary>
/// Versión corregida de la entidad Order.
/// - Se reemplazaron campos públicos por propiedades con get/set.
/// - Se eliminó la mezcla de responsabilidades (cálculo + logging + utilidades estáticas).
/// - Se añadió una propiedad calculada Total para mayor claridad.
/// </summary>
public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Importe total de la orden.
    /// </summary>
    public decimal Total => Quantity * UnitPrice;

    public override string ToString()
    {
        return $"{Id} - {CustomerName} - {ProductName} x{Quantity} = {Total:C}";
    }
}
