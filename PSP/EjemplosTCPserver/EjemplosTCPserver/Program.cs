using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace EjemplosTCPserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //servidor que escucha en cualquier IP en el puerto local

            TcpListener miServerGuapo = new TcpListener(IPAddress.Any, 5000);
            // abre el puerto y empieza a escuchar conexiones entrantes
            miServerGuapo.Start();
            Console.WriteLine("Esperando a que se conecte mi pana...");


            // acepta una conexion entrante
            //AcceptTcpClient es una llamada bloqueante
            // cuando alguien se conecta, devuelve un TcpClient 
            TcpClient cliente = miServerGuapo.AcceptTcpClient();

            Console.WriteLine("Cliente conectado");

            // Obtener el flujo del datos asociado al socket del el cliente asociado
            // todo lo que esriba en flujodatos se enviará al cliente
            NetworkStream flujodatos = cliente.GetStream();

            bool cerrar = false;

             string mensaje = "";

            while (!cerrar)
            {
                Console.WriteLine("Escribe un mensaje: ");
                string mensaje = Console.ReadLine();
                byte[] puroDataChorizo = Encoding.UTF8.GetBytes($"Mensaje del cliente: {mensaje} ");

                flujodatos.Write(puroDataChorizo, 0, puroDataChorizo.Length);

                if (mensaje.ToLower() == "cerrar")
                {
                    cerrar = true;
                }
                
            }
            ;


            // cierra la conexion con el clientardo
            cliente.Close();

            // cierra el servidor guapo y deja de escuchar
            miServerGuapo.Stop();


        }
    }
}
