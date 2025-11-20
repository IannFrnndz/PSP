using System;
using System.Diagnostics;
using System.Threading;

class ProcesoHijo
{
    static void Main(string[] args)
    {
        // Array de países/canicas
        string[] paises;

        // Verificar si se recibieron argumentos del padre
        if (args.Length > 0)
        {
            paises = args[0].Split(';');
        }
        else
        {
            
            paises = new string[] { "España", "Colombia", "Italia", "Alemania", "Japón" };
        }

        int pistas = 2;
        int canicasPorPista = paises.Length;

        for (int pista = 1; pista <= pistas; pista++)
        {
            Console.WriteLine($"Pista {pista}");

            Thread[] canicas = new Thread[canicasPorPista];
            TimeSpan[] tiempos = new TimeSpan[canicasPorPista];

            // Crear hilos para cada canica
            for (int i = 0; i < canicasPorPista; i++)
            {
                int index = i;
                string pais = paises[i];

                canicas[i] = new Thread(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    // Simular avance: 10 ticks
                    for (int t = 0; t < 10; t++)
                    {
                        Thread.Sleep(100 + new Random().Next(50));
                    }

                    sw.Stop();
                    tiempos[index] = sw.Elapsed;

                    Console.WriteLine($"{pais} terminó en {sw.ElapsedMilliseconds} ms");
                });

                canicas[i].Start();
            }

            // Esperar a que todos los hilos terminen
            foreach (var c in canicas)
                c.Join();

            // Mostrar resultados de la pista
            Console.WriteLine($"Resultados Pista {pista}:");

            double mejorTiempo = double.MaxValue;
            string paisGanador = "";

            for (int i = 0; i < canicasPorPista; i++)
            {
                Console.WriteLine($"{paises[i]}: {tiempos[i].TotalMilliseconds} ms");

                if (tiempos[i].TotalMilliseconds < mejorTiempo)
                {
                    mejorTiempo = tiempos[i].TotalMilliseconds;
                    paisGanador = paises[i];
                }
            }

            Console.WriteLine($"Ganador de la pista {pista}: {paisGanador} con {mejorTiempo} ms\n");
        }

        Console.WriteLine("Proceso hijo terminó todas las pistas.");
    }
}
