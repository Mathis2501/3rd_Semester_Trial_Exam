using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_WebApi_praticeExam_01.Models
{

    public sealed class AuctionItemRepository
    {
        private static volatile AuctionItemRepository instance = null;
        private static readonly object padlock = new object();
        
        List<AuctionItem> items;

        public static AuctionItemRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuctionItemRepository();
                    }
                    return instance;
                }
            }
        }
        AuctionItemRepository()
        {
            items = new List<AuctionItem>
                {
                new AuctionItem
                {
                    ItemNumber = 123456,
                    BidPrice = 0,
                    BidCustomerName = "Bjørk",
                    BidCustomerPhone = "66129162",
                    ItemDescription = "PH 5",
                    RatingPrice = 2100m,
                    BidTimeStamp = DateTime.Parse("2016-12-08 07:30")
                },
                new AuctionItem
                {
                    ItemNumber = 123457,
                    BidPrice = 200m,
                    BidCustomerName = "Simon",
                    BidCustomerPhone = "66123123",
                    ItemDescription = "Billede",
                    RatingPrice = 5200m,
                    BidTimeStamp = DateTime.Parse("2016-12-30 06:30")
                },

                };
        }

        

        public static List<AuctionItem> GetAll()
        {
            lock (padlock)
            {
                return Instance.items.ToList(); //returns a copy of the list, but the elements references the old objects
                                                //this is fine as long as you update the list by adding new objects
                                                //to the list, but otherwise changes will be refelcted even in the copy
            }
        }
        public static AuctionItem GetById(int itemNumber)
        {
            lock (padlock)
            {
                return GetAll().Where(x => x.ItemNumber == itemNumber).SingleOrDefault();
            }
        }
        public static void UpdateItem(Bid bid)
        {
            lock (padlock)
            {
                var item = GetById(bid.ItemNumber);
                item.BidPrice = bid.Price;
                item.BidCustomerName = bid.CustomerName;
                item.BidCustomerPhone = bid.CustomerPhone;
                item.BidTimeStamp = DateTime.Now;   
            }
        }
    }
}