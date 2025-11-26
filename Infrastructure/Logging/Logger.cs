using Domain.Interfaces;
using System;

namespace Infrastructure.Logging
{
    public class Logger : ILogger
    {
        public bool Enabled { get; set; } = true;

        public void Log(string message)
        {
            if (!Enabled) return;
            Console.WriteLine($"[LOG] {DateTime.Now} - {message}");
        }

        public void Try(Action action)
        {
            try 
            {
                action(); 
            } 
            catch(Exception ex) 
            { 
                Console.WriteLine($"[LOG] {DateTime.Now} - Logging failure: {ex.Message}");
            }
        }
    }
}
