using System;
using System.Diagnostics;
using System.Threading;

class ChildProcess
{
    static void Main()
    {
        int pistas = 2;
        int canicasPorPista = 2;

        for (int pista = 1; pista <= pistas; pista++)
        {
            Console.WriteLine($"=== Pista {pista} ===");
            Thread[] canicas = new Thread[canicasPorPista];
            TimeSpan[] tiempos = new TimeSpan[canicasPorPista];

            for (int i = 0; i < canicasPorPista; i++)
            {
                int index = i; // necesario para la closure
                canicas[i] = new Thread(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    // Simular avance: 10 "ticks"
                    for (int t = 0; t < 10; t++)
                    {
                        Thread.Sleep(100 + new Random().Next(50)); // trabajo ligero
                    }

                    sw.Stop();
                    tiempos[index] = sw.Elapsed;
                    Console.WriteLine($"Canica {index + 1} terminó en {sw.ElapsedMilliseconds} ms");
                });
                canicas[i].Start();
            }

            // Esperar a que todas las canicas terminen
            foreach (var c in canicas)
                c.Join();

            // Mostrar resultados de la pista
            Console.WriteLine($"Resultados Pista {pista}:");
            for (int i = 0; i < canicasPorPista; i++)
                Console.WriteLine($"Canica {i + 1}: {tiempos[i].TotalMilliseconds} ms");

            Console.WriteLine();
        }

        Console.WriteLine("Proceso hijo terminó todas las pistas.");
    }
}
