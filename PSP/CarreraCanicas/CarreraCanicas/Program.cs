using System;
using System.Diagnostics;
using System.Threading;

class ProcesoHijo
{
    static void Main()
    {
        // Cantidad de pistas que este proceso hijo va a simular
        int pistas = 2;

        // Cantidad de hilos por pista
        int canicasPorPista = 2;

        // Bucle para recorrer cada pista
        for (int pista = 1; pista <= pistas; pista++)
        {
            Console.WriteLine($"Pista {pista}");

            // Array para guardar los hilos de las canicas
            Thread[] canicas = new Thread[canicasPorPista];

            // Array para guardar el tiempo final de cada canica
            TimeSpan[] tiempos = new TimeSpan[canicasPorPista];

            // Crear y arrancar cada canica ,cada una es un hilo
            for (int i = 0; i < canicasPorPista; i++)
            {
                int index = i; 

                // Crear el hilo canica
                canicas[i] = new Thread(() =>
                {
                    // Cronómetro para medir el tiempo de esa canica
                    Stopwatch sw = Stopwatch.StartNew();

                    // Avance en 10 ticks
                    for (int t = 0; t < 10; t++)
                    {
                        // Se duerme un tiempo aleatorio entre 100 y 150 ms
                        Thread.Sleep(100 + new Random().Next(50));
                    }

                    // Detener el cronómetro
                    sw.Stop();

                    // Guardar el tiempo de esta canica
                    tiempos[index] = sw.Elapsed;

                    // Mostrar el resultado por consola
                    Console.WriteLine($"Canica {index + 1} terminó en {sw.ElapsedMilliseconds} ms");
                });

                // Arrancar el hilo
                canicas[i].Start();
            }

            // Esperar a que todas las canicas terminen 
            foreach (var c in canicas)
                c.Join();

            // Mostrar los resultados de la pista completa
            Console.WriteLine($"Resultados Pista {pista}:");
            for (int i = 0; i < canicasPorPista; i++)
                Console.WriteLine($"Canica {i + 1}: {tiempos[i].TotalMilliseconds} ms");

            Console.WriteLine(); 
        }

        
        Console.WriteLine("Proceso hijo terminó todas las pistas.");
    }
}
