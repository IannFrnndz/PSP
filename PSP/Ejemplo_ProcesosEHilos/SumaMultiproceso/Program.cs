using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumaMultiproceso
{

    internal class Program
    {

        // sacamos numeros primos de los 4 rangos y la suma total de cuantos ha habido ellos

        static void Main(string[] args)
        {
            Console.WriteLine("=== Suma multiproceso ===");

            int[,] rangos = new int[4, 2] { { 1, 1000 }, { 1001, 2000 }, { 2001, 3000 }, { 3001, 4000 } };
            long sumaTotal = 0;
            
            

            for (int i = 0; i < rangos.GetLength(0); i++)
            {
                int inicio = rangos[i, 0];
                int fin = rangos[i, 1];

                Process proceso = new Process();
                //"C:\Users\CAMPUSFP\source\repos\EjemploDebugging\EjemploDebugging\bin\Debug\EjemploDebugging.exe"
                //C:\Users\CAMPUSFP\source\repos\EjemploDebugging\EjemploDebugging\bin\Debug\EjemploDebugging.exe
                proceso.StartInfo.FileName = @"C:\programacion\java\PSP\Ejemplo_ProcesosEHilos\Ejemplo_ProcesosEHilos\bin\Debug\Ejemplo_ProcesosEHilos.exe";
                proceso.StartInfo.Arguments = inicio + " " + fin;
                proceso.StartInfo.RedirectStandardOutput = true;
                proceso.StartInfo.UseShellExecute = false;
                proceso.Start();
                

                string salida = proceso.StandardOutput.ReadToEnd();
                proceso.WaitForExit();
                
                long parcial = long.Parse(salida);
                

                Console.WriteLine("Rango " + inicio + "-" + fin + " = " + parcial);
                sumaTotal += parcial;

                //
            }

            Console.WriteLine("\nPrimos totales = " + sumaTotal);
        }
    }
}
