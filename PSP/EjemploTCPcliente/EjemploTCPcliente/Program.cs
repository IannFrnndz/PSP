using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace EjemploTCPcliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creamos un cliente TCP sin conectarme aun
            TcpClient clientardo = new TcpClient();

            // intento conectar al server que este en la ip(localhost , es decir, yo mismo )
            //se bloquea hasta que se conecte o falle
            clientardo.Connect("127.0.0.1",5000);

            // obteno el flujo de datos para recibir datos
            NetworkStream flujillo = clientardo.GetStream();

            
            byte[] yoQuieroBuffer = new byte[1024];

            // read se bloquea hasta que el servidor envie datos
            // devuelve la cantidad de bytes leidos/ recibidos
            int cosasLeidas = flujillo.Read(yoQuieroBuffer, 0, yoQuieroBuffer.Length);

            string mensajardo;

            mensajardo = Encoding.UTF8.GetString(yoQuieroBuffer, 0, cosasLeidas);

            Console.WriteLine("El server te dice esto macho: " + mensajardo);


        }
    }
}
