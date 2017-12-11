using _02_WCF_PracticeExam_01.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _02_WCF_PracticeExam_01
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuctionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuctionService.svc or AuctionService.svc.cs at the Solution Explorer and start debugging.
    public class AuctionService : IAuctionService
    {
        private object _lock = new object();
        public List<AuctionItem> GetAllItems()
        {
            lock (_lock)
            {
                return AuctionItemList.GetList();
            }
        }
        public AuctionItem GetItemById(int itemNumber)
        {
            lock (_lock)
            {
                return AuctionItemList.GetList().Where(x => x.ItemNumber == itemNumber).SingleOrDefault();
            }
        }

        public string MakeBid(Bid bid)
        {
            var item = GetItemById(bid.ItemNumber);
            if (item != null)
            {
                if (bid.Price > item.RatingPrice)
                {
                    item.RatingPrice = bid.Price;
                    item.BidCustomerName = bid.CustomName;

                    item.BidTimeStamp = DateTime.Now;
                    lock (_lock)
                    {
                        AuctionItemList.UpdateItem(item);
                    }
                    return "OK";
                }
                else
                    return "The bid is too low";
            }
            return "The item does not exist";

        }
    }
}
