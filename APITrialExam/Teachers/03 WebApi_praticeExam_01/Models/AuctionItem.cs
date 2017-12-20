using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_WebApi_praticeExam_01.Models
{
    public class AuctionItem
    {
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public decimal RatingPrice { get; set; }
        public decimal BidPrice { get; set; }
        public string BidCustomerName { get; set; }
        public string BidCustomerPhone { get; set; }
        public DateTime BidTimeStamp { get; set; }
    }
}