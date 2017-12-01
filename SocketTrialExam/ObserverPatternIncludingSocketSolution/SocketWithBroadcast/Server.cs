using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketWithBroadcast
{
    public class Server
    {
        private ChatService chatService = new ChatService("chat-room");

        public Server(int port)
        {
            System.Console.WriteLine("Server has been started on port:" + port);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            while (true)
            {
                Console.WriteLine("Server ready");
                Socket clientSocket = listener.AcceptSocket();
                Console.WriteLine("Another chat-member entered the room");
                ClientHandler handler = new ClientHandler(clientSocket, chatService);

                Thread clientThread = new Thread(handler.RunClient);
                clientThread.Start();
            }
        }
    }
}
