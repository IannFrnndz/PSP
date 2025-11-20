using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

class ProcesoPadre
{
    static void Main()
    {
        // Cantidad de procesos hijo que se van a lanzar
        int cantidadHijos = 2;

        // Países que usaremos como canicas
        string[] paises = { "España", "Colombia", "Italia", "Alemania", "Japón" };

        // Convertimos los países a un único string para pasarlo como argumento
        string argumentos = string.Join(";", paises);

        // Ruta completa al ejecutable del proceso hijo
        string rutaHijo = "C:\\programacion\\java\\PSP\\CarreraCanicas\\CarreraCanicas\\bin\\Debug\\CarreraCanicas.exe";

        // Lista donde guardaremos los resultados de todas las canicas/paises
        List<(string proceso, string pais, double tiempo)> resultadosGlobales
            = new List<(string, string, double)>();

        // Regex para capturar: "NombrePais terminó en <tiempo> ms"
        var rx = new Regex(@"^(.*?)\s+terminó.*?([0-9]+(?:\.[0-9]+)?)\s*ms", RegexOptions.IgnoreCase);

        for (int i = 1; i <= cantidadHijos; i++)
        {
            Console.WriteLine($"\nLanzando Proceso Hijo {i}");

            Process p = new Process();
            p.StartInfo.FileName = rutaHijo;

            // PASAMOS LOS PAÍSES COMO ARGUMENTOS
            p.StartInfo.Arguments = argumentos;

            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            // Leer toda la salida del hijo
            string salida = p.StandardOutput.ReadToEnd();

            Console.WriteLine($"--- Salida del Proceso Hijo {i} ---");
            Console.WriteLine(salida);

            p.WaitForExit();

            // Separar la salida en líneas
            string[] lineas = salida.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (string rawLinea in lineas)
            {
                string linea = rawLinea.Trim();
                if (string.IsNullOrEmpty(linea)) continue;

                // Aplicar regex para extraer país y tiempo
                var match = rx.Match(linea);

                if (match.Success)
                {
                    string pais = match.Groups[1].Value.Trim();
                    string tiempoStr = match.Groups[2].Value;

                    double tiempo;
                    double.TryParse(tiempoStr, NumberStyles.Float, CultureInfo.InvariantCulture, out tiempo);

                    // Guardar resultado en la lista global
                    resultadosGlobales.Add(($"Hijo {i}", pais, tiempo));
                }
            }
        }

        // Ordenar la lista global por tiempo ascendente (mejor tiempo primero)
        resultadosGlobales.Sort((a, b) => a.tiempo.CompareTo(b.tiempo));

        // Mostrar la clasificación final global
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("   CLASIFICACIÓN FINAL GLOBAL");
        Console.WriteLine("-------------------------------");

        int pos = 1;
        foreach (var r in resultadosGlobales)
        {
            Console.WriteLine($"{pos}. {r.proceso} - {r.pais} -> {r.tiempo} ms");
            pos++;
        }
    }
}
