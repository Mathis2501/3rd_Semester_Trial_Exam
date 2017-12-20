using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFPracticeExam
{
    public static class AuctionItemRepository
    {
        public static List<AuctionItem> AuctionItems;

        static AuctionItemRepository()
        {
            AuctionItems = new List<AuctionItem>();
            AuctionItems.Add(new AuctionItem() {BidCustomerName = "John", BidCustomerPhone = "32154568", BidPrice = 20, BidTimestamp = DateTime.Now, ItemDescription = "Some Cool Thing", ItemNumber = 1, RatingPrice = 200});
            AuctionItems.Add(new AuctionItem() { BidCustomerName = null, BidCustomerPhone = null, BidPrice = 0, BidTimestamp = new DateTime(), ItemDescription = "Some other Cool Thing", ItemNumber = 2, RatingPrice = 250 });
        }
    }
}