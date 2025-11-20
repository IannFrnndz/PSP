using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;



class ParentProcess
{
    static void Main()
    {
        int cantidadHijos = 2;  // puedes aumentarlo después
        string rutaHijo = "C:\\Users\\Administrador\\Desktop\\PSP\\PSP\\PSP\\CarreraCanicas\\CarreraCanicas\\bin\\Debug\\CarreraCanicas.exe"; // Ajusta si hace falta

        List<(string proceso, string canica, double tiempo)> resultadosGlobales
            = new List<(string, string, double)>();

        // Regex para capturar "Canica <n>" y "<tiempo> ms"
        var rx = new Regex(@"Canica\s+(\d+).*?([0-9]+(?:\.[0-9]+)?)\s*ms", RegexOptions.IgnoreCase);

        for (int i = 1; i <= cantidadHijos; i++)
        {
            Console.WriteLine($"\n=== Lanzando Proceso Hijo {i} ===");

            Process p = new Process();
            p.StartInfo.FileName = rutaHijo;
            p.StartInfo.RedirectStandardOutput = true;  // leer consola del hijo
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            // Leer la salida del hijo
            string salida = p.StandardOutput.ReadToEnd();

            Console.WriteLine($"--- Salida del Proceso Hijo {i} ---");
            Console.WriteLine(salida);

            p.WaitForExit();

            // Procesar resultados:
            string[] lineas = salida.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (string rawLinea in lineas)
            {
                string linea = rawLinea.Trim();
                if (string.IsNullOrEmpty(linea)) continue;

                var match = rx.Match(linea);
                if (match.Success)
                {
                    string canica = match.Groups[1].Value;
                    string tiempoStr = match.Groups[2].Value;
                    double tiempo;
                    if (!double.TryParse(tiempoStr, NumberStyles.Float, CultureInfo.InvariantCulture, out tiempo))
                    {
                        // Intentar parsear con la cultura actual si falla
                        double.TryParse(tiempoStr, out tiempo);
                    }

                    resultadosGlobales.Add((
                        $"Hijo {i}",
                        $"Canica {canica}",
                        tiempo));
                }
                else
                {
                    // Línea con "Canica" pero no en el formato esperado: útil para depuración
                    if (linea.IndexOf("Canica", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine($"[AVISO] Línea no reconocida: \"{linea}\"");
                    }
                }
            }
        }

        // ORDENAR CLASIFICACIÓN GLOBAL
        resultadosGlobales.Sort((a, b) => a.tiempo.CompareTo(b.tiempo));

        Console.WriteLine("\n==============================");
        Console.WriteLine("   CLASIFICACIÓN FINAL GLOBAL");
        Console.WriteLine("============================== ");

        int pos = 1;
        foreach (var r in resultadosGlobales)
        {
            Console.WriteLine($"{pos}. {r.proceso} - {r.canica} -> {r.tiempo} ms");
            pos++;
        }
    }
}