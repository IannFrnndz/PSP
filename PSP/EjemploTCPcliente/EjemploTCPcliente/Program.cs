using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteTCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creamos un cliente TCP sin conectarme aun
            TcpClient clientardo = new TcpClient();

            // intento conectar al server que este en la ip(localhost , es decir, yo mismo )
            //se bloquea hasta que se conecte o falle
            clientardo.Connect("127.0.0.1", 5000);

            // obteno el flujo de datos para recibir datos
            NetworkStream flujillo = clientardo.GetStream();


            byte[] yoQuieroBuffer = new byte[1024];

            while (true) // bucle para recibir múltiples mensajes
            {
                int cosasLeidas = flujillo.Read(yoQuieroBuffer, 0, yoQuieroBuffer.Length);
                if (cosasLeidas == 0) break; // se desconectó el servidor

                string mensajardo = Encoding.UTF8.GetString(yoQuieroBuffer, 0, cosasLeidas);
                Console.WriteLine("El server te dice esto macho: " + mensajardo);
            }

            clientardo.Close();
        }
    }
}