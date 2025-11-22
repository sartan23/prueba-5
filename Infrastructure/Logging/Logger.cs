using System;

namespace Infrastructure.Logging;

public static class Logger
{
    private static bool enabled = true;

    public static bool Enabled { get => enabled; set => enabled = value; }

    public static void Log(string message)
    {
        if (!Enabled) return;
        Console.WriteLine("[LOG] " + DateTime.Now + " - " + message);
    }

    public static void Try(Action a)
    {
        try { a(); } catch { Console.WriteLine("[ERROR]: La aplicación ha fallado"); }
    }
}
