using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Diagnostics;
using System.Threading;

namespace Ejemplo_ProcesosEHilos
{
    class HilosAunMasGuapos
    {
        public void EjemploHilos0()
        {
            for (int i = 1; i <= 60; i++)
            {
                Console.WriteLine("Hilo secundario: i = " + i);
                Thread.Sleep(1000);
            }
        }

        public void EjemploTrabajoHiloPrincipal()
        {
            for (int j = 0;j <= 5; j++)
            {
               
                Thread.Sleep(10000);
                Console.WriteLine("Continuo trabajando");
            }

            Console.WriteLine("Fin del hilo principal");
        }

        public void EjemploHilos1(object valor)
        {
            char id = (char)valor;
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Hilo " + id + ": i = " + i);
                Thread.Sleep(2000);
            }
           
        }
    }

    internal class Program
    {



        class ProcesosGuapardos
        {
            //Process paint = Process.Start("mspaint.exe");
            public void EjemploProcesos0()
            {
                Console.WriteLine("Hola, que programa quieres abrir??");

                bool input_valido = false;
                while (!input_valido)
                {

                    Console.WriteLine("1. Calculadora");
                    Console.WriteLine("2. Explorador de carpetas de Windows");
                    Console.WriteLine("3. Paint");



                    // le ponemos un true para que no se vea la tecla pulsada
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1)
                    {


                        Console.WriteLine("Lanzando calculadora");

                        Process calculadora = Process.Start("calc.exe");
                    }
                    else if (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine("Lanzando el explorador de carpetas");
                        Process calculadora = Process.Start("explorer.exe");

                    }
                    else if (key.Key == ConsoleKey.NumPad3 || key.Key == ConsoleKey.D3)
                    {

                        Console.WriteLine("Lanzando MSPaint");
                        Process paint = Process.Start("mspaint.exe");

                        // esperate a que el proceso termine, vamos que se cierre el paint
                        // los inputs se guardan, tendriamos que hacer una limpieza de buffer

                        paint.WaitForExit();

                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(true);
                        }

                        Console.WriteLine("Cerrando MSPaint...");


                    }
                    else
                    {
                        Console.WriteLine("Se pulso otra tecla");
                    }
                }

            }
        }
        static void Main(string[] args)
        {

            // Ejercicio de contador de segundos con hilos

            //ProcesosGuapardos p = new ProcesosGuapardos();

            HilosAunMasGuapos h = new HilosAunMasGuapos();

            //Thread hilo = new Thread(h.EjemploHilos0);

            //hilo.Start();

            //h.EjemploTrabajoHiloPrincipal();

            Thread hilo1 = new Thread(new ParameterizedThreadStart(h.EjemploHilos1));
            Thread hilo2 = new Thread(new ParameterizedThreadStart(h.EjemploHilos1));
            Thread hilo3 = new Thread(new ParameterizedThreadStart(h.EjemploHilos1));
            
            hilo1.Start('a');
            hilo2.Start('b');
            hilo3.Start('c');

            //p.EjemploProcesos0();

            //if (args.Length < 2)
            //{
            //    Console.WriteLine("Uso: Subproceso_SumaParcial <inicio> <fin>");
            //    return;
            //}

            //int inicio = int.Parse(args[0]);
            //int fin = int.Parse(args[1]);
            //long suma = 0;
            //long numPrimos = 0;

            //for (int i = inicio; i <= fin; i++)
            //{
            //    suma += i;
            //    if (EsPrimo(i))
            //    {
            //        numPrimos++;
            //    }

            //}

            //Console.WriteLine(numPrimos);

            //bool EsPrimo(int numero)
            //{
            //    if (numero < 2) return false;
            //    if (numero == 2) return true;
            //    if (numero % 2 == 0) return false;

            //    for (int i = 3; i <= Math.Sqrt(numero); i += 2)
            //    {
            //        if (numero % i == 0)
            //            return false;
            //    }
            //    return true;
            //}
        }
    }
}
