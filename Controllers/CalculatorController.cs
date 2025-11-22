using BadCalc_VeryBad.Models;
using BadCalc_VeryBad.Services;
using BadCalc_VeryBad.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BadCalc_VeryBad.Controllers
{
    public class CalculatorController
    { 
        /// Muestra el menú principal y gestiona el flujo de la app.
        public void Run()
        {
            bool running = true;

            while (running)
            {
                ShowMenu();
                Console.Write("Opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "0": running = false; break;
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6": HandleBinaryOperation(option); break;
                    case "7": HandleSqrt(); break;
                    case "8": ShowHistory(); break;
                    default:
                        Console.WriteLine("❌ Opción inválida. Intenta de nuevo.");
                        break;
                }
            }

            SaveHistory();
            Console.WriteLine("Programa finalizado correctamente ✅");
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\nSeleccione una operación:");
            Console.WriteLine("1) Suma");
            Console.WriteLine("2) Resta");
            Console.WriteLine("3) Multiplicación");
            Console.WriteLine("4) División");
            Console.WriteLine("5) Potencia");
            Console.WriteLine("6) Módulo");
            Console.WriteLine("7) Raíz cuadrada");
            Console.WriteLine("8) Ver historial");
            Console.WriteLine("0) Salir\n");
        }

        private static void HandleBinaryOperation(string option)
        {
            Console.Write("Ingrese el valor de A: ");
            string a = Console.ReadLine();

            Console.Write("Ingrese el valor de B: ");
            string b = Console.ReadLine();

            string op = option switch
            {
                "1" => "+",
                "2" => "-",
                "3" => "*",
                "4" => "/",
                "5" => "^",
                "6" => "%",
                _ => ""
            };

            double result = Calculator.DoOperation(a, b, op);
            Console.WriteLine($"= {result.ToString(CultureInfo.InvariantCulture)}");

            string record = $"{a}|{b}|{op}|{result.ToString("0.###############", CultureInfo.InvariantCulture)}";
            Globals.AddToHistory(record);
            FileHelper.SaveLineToFile("history.txt", record);
        }

        private static void HandleSqrt()
        {
            Console.Write("Ingrese el valor: ");
            string a = Console.ReadLine();
            double result = Calculator.SafeSqrt(a);
            Console.WriteLine($"= {result.ToString(CultureInfo.InvariantCulture)}");

            string record = $"{a}| |sqrt|{result.ToString("0.###############", CultureInfo.InvariantCulture)}";
            Globals.AddToHistory(record);
            FileHelper.SaveLineToFile("history.txt", record);
        }

        private static void ShowHistory()
        {
            var history = Globals.GetHistory();
            if (history.Count == 0)
            {
                Console.WriteLine("(Historial vacío)");
                return;
            }

            Console.WriteLine("\n--- HISTORIAL ---");
            foreach (var item in history)
                Console.WriteLine(item);
            Console.WriteLine("-----------------\n");
        }

        private static void SaveHistory()
        {
            try
            {
                var history = Globals.GetHistory();
                FileHelper.SaveAll("final_history.tmp", history);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ No se pudo guardar el historial final: {ex.Message}");
            }
        }
    }

}

