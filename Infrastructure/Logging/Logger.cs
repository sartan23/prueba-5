using System;

namespace Infrastructure.Logging;

/// <summary>
/// Versión simplificada del logger para el ejemplo.
/// Se evita el uso de flags estáticos y bloques try/catch vacíos que ocultaban errores.
/// </summary>
public static class Logger
{
    public static void LogInformation(string message)
    {
        Console.WriteLine($"[INFO] {{DateTime.Now:O}} - {message}");
    }

    public static void LogError(string message, Exception ex)
    {
        Console.WriteLine($"[ERROR] {{DateTime.Now:O}} - {message} :: {{ex.Message}}");
    }
}
