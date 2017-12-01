using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketWithBroadcast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter port number to set up server");
            string strPort = Console.ReadLine();
            if (strPort.Trim() == "")
                strPort = "12000";

            int port = int.Parse(strPort);

            new Server(port);
        }
    }
}
