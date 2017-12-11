using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AuctionService.AuctionServiceClient client = new AuctionService.AuctionServiceClient();
            var result = client.GetAllItems();
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());

            }

            string message = client.MakeBid(new AuctionService.Bid { CustomName = "Simon", ItemNumber = 1, Phone = "12345678", Price = 30.0m });
            Console.WriteLine(message);
            Console.WriteLine(client.GetItemById(1).ToString());
            Console.ReadLine();
        }
    }
}
