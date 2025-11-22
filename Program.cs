
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using BadCalc_VeryBad.Controllers;


namespace BadCalcVeryBad
{
    /// Punto de entrada principal del programa.
    /// Solo se instancia y ejecuta el controlador.
     static class Program
    {
        static void Main(string[] args)
        {
            var controller = new CalculatorController();
            controller.Run();
        }
    }
                         
}
