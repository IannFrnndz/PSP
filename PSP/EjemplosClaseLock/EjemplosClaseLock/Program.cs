using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EjemplosClaseLock
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            TestCandado();
           
        }


        static List<int> numerines = new List<int>();

        static object candado = new object();
        private static void TestCandado()
        {
            Thread t1 = new Thread(AgregarNumeros);
            Thread t2 = new Thread(AgregarNumeros);
            Thread t3 = new Thread(AgregarNumeros);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            // va a sumar todos los numeros
            Console.WriteLine("Numerines: " + numerines.Count);
        }
        private static void AgregarNumeros()
        {
            for (int i = 0; i < 10000; i++)
            {

                {
                    // el objeto solo se mete para controlar el lock
                    lock (candado)
                    {
                        numerines.Add(i);
                    }
                    
                }
            }
        }
    }
}
