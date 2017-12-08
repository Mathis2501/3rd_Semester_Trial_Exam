using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFPracticeExam
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private object _lock;
        public AuctionItem GetAuctionItem(int itemNumber)
        {
            lock (_lock)
            {
                return AuctionItemRepository.AuctionItems.Find(x => x.ItemNumber == itemNumber);
            }
        }

        public List<AuctionItem> GetAuctionItems()
        {
            lock (_lock)
            {
                return AuctionItemRepository.AuctionItems;
            }
        }

        public string BidOnItem(Bid newBid)
        {
            lock (_lock)
            {
                AuctionItem AI = AuctionItemRepository.AuctionItems.Find(x => x.ItemNumber == newBid.ItemNumber);
                if (AI.BidPrice < newBid.Price)
                {
                    AI.BidPrice = newBid.Price;
                    AI.BidCustomerName = newBid.CustomName;
                    AI.BidCustomerPhone = newBid.CustomPhone;
                    AI.BidTimestamp = DateTime.Now;
                    return "OK";
                }
                else if (AI != null)
                {
                    return "Bid too low";
                }
                else
                {
                    return "Item does not exist";
                }
            }
        }
    }
}
