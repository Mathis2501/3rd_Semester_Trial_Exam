using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener serverSocket = new TcpListener(IPAddress.Any, 20000);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine(" >> Server Started");

            while (true)
            {
                counter += 1;
                var clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >> Client No: " + counter + " Started!");
                HandleClient client = new HandleClient();
                client.StartClient(clientSocket);
            }
        }

        public class HandleClient
        {
            private TcpClient clientSocket;

            internal void StartClient(TcpClient inClientSocket)
            {
                this.clientSocket = inClientSocket;
                Thread newThread = new Thread(ClientHandler);
                newThread.Start();

            }

            internal void ClientHandler()
            {
                while (true)

                {
                    IPEndPoint remoteIpEndPoint = clientSocket.Client.RemoteEndPoint as IPEndPoint;
                    IPEndPoint localIpEndPoint = clientSocket.Client.LocalEndPoint as IPEndPoint;

                    NetworkStream stream = new NetworkStream(clientSocket.Client);
                    StreamReader reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.AutoFlush = true;

                    if (remoteIpEndPoint != null)
                    {
                        Console.WriteLine("I am connected to " + remoteIpEndPoint.Address + " on port number " +
                                          remoteIpEndPoint.Port);
                    }

                    if (localIpEndPoint != null)
                    {
                        Console.WriteLine("My local IpAddress is :" + localIpEndPoint.Address +
                                          " I am connected on port number " + localIpEndPoint.Port);
                    }

                    while (clientSocket.Client.Connected)
                    {
                        string request = reader.ReadLine();
                        Console.WriteLine(request);
                        if (!string.IsNullOrWhiteSpace(request))
                        {
                            string command = "";
                            string path = "";
                            string options = "";
                            if (request.Split(' ').Length >= 2)
                            {
                                command = request.Split(' ')[0];
                                path = request.Split(' ')[1];
                            }
                            if (request.Split(' ').Length == 3)
                            {
                                options = request.Split(' ')[2];
                            }

                            switch (command)
                            {
                                case "DirInfo":
                                    if (CanGetDirInfo(path))
                                    {
                                        writer.WriteLine(GetDirInfo(request.Split(' ')[1]));
                                        if (options != "")
                                        {
                                            if (options.Contains("s"))
                                            {
                                                foreach (var item in GetSubDirInfo(path))
                                                {
                                                    Console.WriteLine(item);
                                                    writer.WriteLine("Directory Name: " + item);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        writer.WriteLine("Error: Directory could not be found");
                                    }
                                    break;

                                default:
                                    writer.WriteLine("Unknown command");
                                    break;
                            }
                        }
                    }
                }
            }

            private IEnumerable<string> GetSubDirInfo(string path)
            {
                DirectoryInfo DI = new DirectoryInfo(path);
                foreach (var item in DI.GetDirectories())
                {
                    yield return item.Name;
                }
            }

            private bool CanGetDirInfo(string path)
            {
                DirectoryInfo DI = new DirectoryInfo(path);
                Console.WriteLine(DI.Exists);
                return DI.Exists;
            }

            private string GetDirInfo(string path)
            {
                DirectoryInfo DI = new DirectoryInfo(path);
                string dirInfo = "Directory Name: " + DI.Name + " \tCreated on: " + DI.CreationTime;
                Console.WriteLine(dirInfo);
                return dirInfo;
            }
        }
    }
}
