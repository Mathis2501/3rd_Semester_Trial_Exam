using _03_WebApi_praticeExam_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _03_WebApi_praticeExam_01.Controllers
{
    public class AuctionController : ApiController
    {
        //GET: api/Auction
        public IEnumerable<AuctionItem> Get()
        {
            return AuctionItemRepository.GetAll();
        }

        // GET: api/Auction/123456
        public AuctionItem Get(int itemNumber)
        {
            return AuctionItemRepository.GetById(itemNumber);
        }

        // PUT: api/Auction
        public HttpResponseMessage Put([FromBody]Bid bid)
        {
            var item = AuctionItemRepository.GetById(bid.ItemNumber); 
            if (item != null)
            {
                if (bid.Price > item.BidPrice)
                {
                    AuctionItemRepository.UpdateItem(bid);
                }
                else if (bid.Price < item.BidPrice)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "The bid is too low");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The item could not be found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "OK");

        }
        
    }
}
