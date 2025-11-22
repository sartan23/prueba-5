using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BadCalc_VeryBad.Utils
{

    /// Clase auxiliar que maneja las operaciones con archivos.

    public static class FileHelper
    {
        public static void SaveLineToFile(string path, string content)
        {
            try
            {
                File.AppendAllText(path, content + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Error al guardar historial: {ex.Message}");
            }
        }

        public static void SaveAll(string path, List<string> content)
        {
            try
            {
                File.WriteAllLines(path, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Error al guardar archivo completo: {ex.Message}");
            }
        }
    }
}

