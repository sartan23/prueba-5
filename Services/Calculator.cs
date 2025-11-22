using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCalc_VeryBad.Services
{
 
    /// Servicio que contiene la lógica matemática.
    /// No depende de la interfaz de usuario.

    public static class Calculator
    {
        public static double DoOperation(string inputA, string inputB, string operation)
        {
            double a = TryParse(inputA);
            double b = TryParse(inputB);

            return operation switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => SafeDivide(a, b),
                "^" => Math.Pow(a, b),
                "%" => a % b,
                _ => double.NaN
            };
        }

        private static double SafeDivide(double a, double b)
        {
            const double epsilon = 1e-10;

            if (Math.Abs(b) < epsilon)
            {
                Console.WriteLine("⚠ División por cero (o valor muy pequeño). Se usa valor aproximado.");

                double sign;
                if (b > epsilon)
                    sign = 1.0;
                else if (b < -epsilon)
                    sign = -1.0;
                else
                    sign = 1.0;

                return a / epsilon * sign;
            }

            return a / b;
        }



        private static double TryParse(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            if (double.TryParse(s.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                return result;
            return 0;
        }

        public static double SafeSqrt(string input)
        {
            double value = TryParse(input);
            if (value < 0)
            {
                Console.WriteLine("⚠ Valor negativo, se toma raíz del valor absoluto (resultado negativo).");
                return -Math.Sqrt(Math.Abs(value));
            }
            return Math.Sqrt(value);
        }
    }

}

