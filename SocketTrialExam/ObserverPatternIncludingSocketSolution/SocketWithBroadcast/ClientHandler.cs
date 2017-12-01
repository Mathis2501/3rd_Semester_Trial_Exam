using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketWithBroadcast
{
    public class ClientHandler //this is the observer
    {
        private Socket clientSocket;
        private ChatService chatService;

        private NetworkStream netStream;
        private StreamWriter writer;
        private StreamReader reader;

        public ClientHandler(Socket clientSocket, ChatService chatService) //same chat service for every thread
        {
            this.clientSocket = clientSocket;
            this.chatService = chatService;
        }

        public void RunClient()
        {
            netStream = new NetworkStream(clientSocket);
            writer = new StreamWriter(netStream);
            reader = new StreamReader(netStream);

            Dialog();

            writer.Close();
            reader.Close();
            netStream.Close();
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            
    }

        private void SendMessageToClient(string text)
        {
            writer.WriteLine(text);
            writer.Flush();
        }

        private string ReceiveMessageFromClient()
        {
            try
            {
                return reader.ReadLine();
            }
            catch
            {
                return null;
            }
        }

        private void Dialog()
        {
            try
            {
                SendMessageToClient("Enter: <bye> to end communication");
                chatService.BroardCastEvent += this.BroadcastAction; //Which method to fire when ready (subscription)

                while (ExecuteCommand()) ;
            }
            catch
            {
            }
            finally
            {
                chatService.BroardCastEvent -= this.BroadcastAction; //unsubscribe
            }
        }

        private bool ExecuteCommand()
        {
            string input = ReceiveMessageFromClient();

            if (input == null)
                return false;
            if (input.Trim().ToLower() == "bye")
                return false;

            chatService.BroadCastMessage(input); //Fire the event

            return true;
        }

        public void BroadcastAction(string msg)
        {
            SendMessageToClient("Broadcast:" + msg);
        }


    }
}
