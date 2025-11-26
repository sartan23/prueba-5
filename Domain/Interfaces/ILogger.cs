using System;

namespace Domain.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void Try(Action action);
    }
}