using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02_WCF_PracticeExam_01.DAL
{
    public static class AuctionItemList
    {
        public static List<AuctionItem> items;

        static AuctionItemList()
        {

            items = new List<AuctionItem> {
                new AuctionItem {  ItemNumber=1, ItemDescription= "Test1", RatingPrice = 20.0m, BidCustomerName="Simon", BidCustomerPhone="12345678", BidPrice=25.0m, BidTimeStamp=DateTime.Now.AddDays(-7) },
                new AuctionItem { ItemNumber=2, ItemDescription="Test2", RatingPrice = 250.0m, BidCustomerName="Simon2", BidCustomerPhone="12345678", BidPrice=251.0m, BidTimeStamp=DateTime.Now.AddDays(-28) },
                new AuctionItem { ItemNumber=3, ItemDescription="Test3", RatingPrice = 10.0m, BidCustomerName="", BidCustomerPhone="", BidPrice=0.0m, BidTimeStamp=DateTime.Now }
            };

        }

        public static List<AuctionItem> GetList()
        {
            return items;

        }

        internal static void UpdateItem(AuctionItem item)
        {
            var index = items.FindIndex(c => c.ItemNumber == item.ItemNumber);
            items[index] = item;
        }
    }
}