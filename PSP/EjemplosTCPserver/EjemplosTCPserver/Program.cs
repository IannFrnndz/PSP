using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServidorTCPDef
{
    internal class Program
    {
        // Lista de todos los clientes conectados, así podemos manejar varios a la vez
        static List<TcpClient> clientesConectados = new List<TcpClient>();

        static void Main(string[] args)
        {
            int numerocliente = 0;

            // Servidor que escucha en cualquier IP local, puerto 5000
            TcpListener miserverguapo = new TcpListener(IPAddress.Any, 5000);
            miserverguapo.Start();
            Console.WriteLine("Esperando a que se conecten los clientes...");

            // Bucle infinito para aceptar clientes continuamente
            while (true)
            {
                // AcceptTcpClient se bloquea hasta que un cliente se conecte
                TcpClient cliente = miserverguapo.AcceptTcpClient();
                clientesConectados.Add(cliente); // lo agregamos a la lista
                Console.WriteLine("Cliente conectado");
                numerocliente++;

                // Crear una tarea/hilo para manejar este cliente sin bloquear a los demás
                Thread t = new Thread(() => ManejarCliente(cliente, numerocliente));
                t.Start();
            }

        }

        // Método para manejar la comunicación con un cliente específico
        private static void ManejarCliente(TcpClient cliente, int clinum)
        {
            // Obtener el flujo de datos del cliente
            NetworkStream flujodatos = cliente.GetStream();

            // Bucle para enviar mensajes al cliente mientras no escribamos "salir"
            while (true)
            {
                string enviarnumerocliente = "Cliente: " + clinum;
                Console.Write("Escribe un mensaje para el cliente cliente " + clinum + ": ");
                string mensajeDelServidor = Console.ReadLine();
                byte[] purodatachorizo = Encoding.UTF8.GetBytes(mensajeDelServidor);

                // Enviar los bytes al cliente
                flujodatos.Write(purodatachorizo, 0, purodatachorizo.Length);

                // Si escribimos "salir", cerramos la conexión con este cliente
                if (mensajeDelServidor.ToLower() == "salir")
                    break;
            }

            // Cerramos la conexión con el cliente
            cliente.Close();
            // Lo quitamos de la lista de clientes conectados
            clientesConectados.Remove(cliente);
        }
    }

    
    }