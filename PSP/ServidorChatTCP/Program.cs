using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets; // Para usar TCPListener y TcpClient
using System.Text;        // Para codificar y decodificar mensajes
using System.Threading;   // Para manejar hilos (threads)

namespace ServidorChatTCP
{
    class Program
    {
        private static TcpListener listener;           // Escucha conexiones entrantes
        private static List<TcpClient> clients = new List<TcpClient>(); // Lista de clientes conectados
        private static object lockClients = new object(); // Lock para proteger la lista de clientes en múltiples hilos
        private static bool serverRunning = true;       // Controla si el servidor sigue activo

        static void Main(string[] args)
        {
            listener = new TcpListener(IPAddress.Any, 5000); // Escucha en cualquier IP en el puerto 5000
            listener.Start();                                // Inicia el listener
            Console.WriteLine("Servidor TCP iniciado en puerto 5000...");

            while (serverRunning) // Bucle principal del servidor
            {
                TcpClient cliente = listener.AcceptTcpClient(); // Espera y acepta un cliente entrante

                lock (lockClients) // Protege la lista de clientes para evitar conflictos
                {
                    clients.Add(cliente); // Agrega el cliente a la lista
                }

                Console.WriteLine("Cliente conectado: " + cliente.Client.RemoteEndPoint); // Muestra info del cliente

                // Crea un hilo para manejar la comunicación con este cliente
                Thread t = new Thread(HandleClient);
                t.IsBackground = true;  // Hilo en segundo plano (no bloquea al cerrar)
                t.Start(cliente);       // Pasa el cliente al hilo
            }
        }

        
        private static void HandleClient(object obj)
        {
            TcpClient cliente = (TcpClient)obj; 
            NetworkStream stream = cliente.GetStream(); 
            byte[] buffer = new byte[1024];     

            try
            {
                while (true) 
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length); 
                    if (bytesRead <= 0) break; 

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim(); 
                    if (msg.Length == 0) continue; 

                    Console.WriteLine($"[{cliente.Client.RemoteEndPoint}] dice: {msg}"); 
                    Broadcast(cliente, $"[{cliente.Client.RemoteEndPoint}]: {msg}");  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cliente {cliente.Client.RemoteEndPoint}: {ex.Message}"); 
            }

            
            lock (lockClients)
            {
                clients.Remove(cliente);
            }
            Console.WriteLine("Cliente desconectado: " + cliente.Client.RemoteEndPoint);
            cliente.Close(); 
        }

       
        private static void Broadcast(TcpClient sender, string mensaje)
        {
            byte[] data = Encoding.UTF8.GetBytes(mensaje + "\n"); 
            lock (lockClients) 
            {
                foreach (var c in clients)
                {
                    if (c == sender) continue;
                    try
                    {
                        NetworkStream s = c.GetStream();
                        s.Write(data, 0, data.Length);  
                    }
                    catch
                    {
                       
                    }
                }
            }
        }
    }
}