using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCalc_VeryBad.Models
{

    /// Almacena de forma centralizada el historial de operaciones.
    public static class Globals
    {
       private static readonly List<string> _history = new List<string>();
       public static void AddToHistory(string entry) => _history.Add(entry);
       public static List<string> GetHistory() => new List<string>(_history);
        
    }
}
