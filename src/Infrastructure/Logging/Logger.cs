using Domain.Abstractions;
using System;

namespace Infrastructure.Logging;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[INFO] {DateTime.Now:O} {message}");
    }

    public void LogError(string message, Exception ex) 
    {
            Console.WriteLine($"[ERROR] {DateTime.Now:O} {message} -- {ex.Message}");
    }
}
