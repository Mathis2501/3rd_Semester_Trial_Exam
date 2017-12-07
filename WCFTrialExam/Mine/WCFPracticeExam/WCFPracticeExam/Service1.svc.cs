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
                foreach (var item in AuctionItemRepository.AuctionItems)
                {
                    if (item.ItemNumber == itemNumber)
                    {
                        return item;
                    }
                }
                return null;
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
                foreach (var item in AuctionItemRepository.AuctionItems)
                {
                    if (item.ItemNumber == newBid.ItemNumber)
                    {
                        if (item.BidPrice < newBid.Price)
                        {
                            item.BidPrice = newBid.Price;
                            item.BidCustomerName = newBid.CustomName;
                            item.BidCustomerPhone = newBid.CustomPhone;
                            item.BidTimestamp = DateTime.Now;
                            return "OK";
                        }
                        return "Bid too low";
                    }
                }
            }
            return "Item does not exist";
        }
    }
}
