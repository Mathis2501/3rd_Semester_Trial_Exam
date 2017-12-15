using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWebApplication.Models;

namespace WebApiWebApplication.Controllers
{
    public class AuctionController : ApiController
    {
        private static object _lock = new object();
        // GET: api/Auction
        public List<AuctionItem> GetAuctionItems()
        {
            lock (_lock)
            {
                return AuctionItemRepository.AuctionItems;
            }
        }

        // GET: api/Auction/5
        public AuctionItem GetAuctionItem(int id)
        {
            lock (_lock)
            {
                return AuctionItemRepository.AuctionItems.Find(x => x.ItemNumber == id);
            }
        }

        // POST: api/Auction
        
        public string Post([FromBody]Bid newBid)
        {
            lock (_lock)
            {
                AuctionItem AI = AuctionItemRepository.AuctionItems.Find(x => x.ItemNumber == newBid.ItemNumber);
                if (AI != null)
                {
                    return "Bid too low";
                }
                else if (AI.BidPrice < newBid.Price)
                {
                    AI.BidPrice = newBid.Price;
                    AI.BidCustomerName = newBid.CustomName;
                    AI.BidCustomerPhone = newBid.CustomPhone;
                    AI.BidTimestamp = DateTime.Now;
                    return "OK";
                }
            }
            return "Item does not exist";
        }
        

        // PUT: api/Auction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auction/5
        public void Delete(int id)
        {
        }
    }
}
