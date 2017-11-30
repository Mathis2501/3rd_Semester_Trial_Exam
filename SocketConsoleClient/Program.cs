using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//
namespace SocketConsoleClient
{
    class Program
    {
        
        private StreamReader reader;

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            
            TcpClient client = new TcpClient();
            Console.WriteLine("Connecting...");

            client.Connect("localhost", 20000);

            Console.Clear();
            Console.WriteLine("Connected");

            NetworkStream stream; stream = client.GetStream();
            reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            Thread serverReader = new Thread(ReadFromServer);
            serverReader.Start();

            while (client.Connected)
            {
                writer.WriteLine(Console.ReadLine());
            }
        }

        private void ReadFromServer()
        {
            while (true)
            {
                string msg = reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    Console.WriteLine(msg);
                }
                Thread.Sleep(10);
            }
        }
    }
}
