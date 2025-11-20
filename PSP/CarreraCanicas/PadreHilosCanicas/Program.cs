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

        // Ruta completa al ejecutable del proceso hijo (CarreraCanicas.exe)
        string rutaHijo = "C:\\Users\\Administrador\\Desktop\\PSP\\PSP\\PSP\\CarreraCanicas\\CarreraCanicas\\bin\\Debug\\CarreraCanicas.exe";

        // Lista donde guardaremos los resultados de todas las canicas de todos los procesos hijo
        List<(string proceso, string canica, double tiempo)> resultadosGlobales
            = new List<(string, string, double)>();

        // Expresión regular para extraer “Canica <n>” y “<tiempo> ms” de cada línea
        var rx = new Regex(@"Canica\s+(\d+).*?([0-9]+(?:\.[0-9]+)?)\s*ms", RegexOptions.IgnoreCase);

        // Bucle para lanzar la cantidad de procesos hijo indicada
        for (int i = 1; i <= cantidadHijos; i++)
        {
            Console.WriteLine($"\nLanzando Proceso Hijo {i}");

            // Crear el proceso hijo
            Process p = new Process();
            p.StartInfo.FileName = rutaHijo;           // Ruta del .exe hijo
            p.StartInfo.RedirectStandardOutput = true; // Leer el texto que escriba en consola
            p.StartInfo.UseShellExecute = false;       // Necesario para permitir la redirección
            p.StartInfo.CreateNoWindow = true;         // No mostrar ventana

            // Ejecutar el proceso hijo
            p.Start();

            // Leer toda la salida del proceso hijo
            string salida = p.StandardOutput.ReadToEnd();

            Console.WriteLine($"--- Salida del Proceso Hijo {i} ---");
            Console.WriteLine(salida);

            // Esperar a que el proceso hijo termine por completo
            p.WaitForExit();

            // Separar la salida en líneas individuales para analizarlas
            string[] lineas = salida.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Analizar cada línea de texto generada por el proceso hijo
            foreach (string rawLinea in lineas)
            {
                string linea = rawLinea.Trim();         // Quitar espacios al inicio y final
                if (string.IsNullOrEmpty(linea)) continue; // Ignorar líneas vacías

                // Intentar aplicar la expresión regular a la línea
                var match = rx.Match(linea);
                if (match.Success)
                {
                    // match.Groups[1] = número de la canica
                    // match.Groups[2] = tiempo en ms capturado por regex
                    string canica = match.Groups[1].Value;
                    string tiempoStr = match.Groups[2].Value;

                    double tiempo;

                    // Intentar convertir el texto del tiempo a número (primero usando cultura invariante)
                    if (!double.TryParse(tiempoStr, NumberStyles.Float, CultureInfo.InvariantCulture, out tiempo))
                    {
                        // Si falla, intentarlo de nuevo usando la cultura del sistema
                        double.TryParse(tiempoStr, out tiempo);
                    }

                    // Guardar el resultado en la lista global
                    resultadosGlobales.Add((
                        $"Hijo {i}",
                        $"Canica {canica}",
                        tiempo));
                }
                else
                {
                    // Si la línea contiene la palabra "Canica" pero no coincide con el formato esperado,
                    // mostramos un aviso para depuración.
                    if (linea.IndexOf("Canica", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine($"[AVISO] Línea no reconocida: \"{linea}\"");
                    }
                }
            }
        }

        // Ordenar la lista global por el tiempo (ascendente, mejor tiempo primero)
        resultadosGlobales.Sort((a, b) => a.tiempo.CompareTo(b.tiempo));

        // Mostrar la clasificación final global
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("   CLASIFICACIÓN FINAL GLOBAL");
        Console.WriteLine("-------------------------------");

        int pos = 1;
        foreach (var r in resultadosGlobales)
        {
            Console.WriteLine($"{pos}. {r.proceso} - {r.canica} -> {r.tiempo} ms");
            pos++;
        }
    }
}
