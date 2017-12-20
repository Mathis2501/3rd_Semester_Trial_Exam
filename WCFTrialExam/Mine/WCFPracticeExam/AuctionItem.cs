using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFPracticeExam
{
    [DataContract]
    public class AuctionItem
    {
        [DataMember]
        public int ItemNumber { get; set; }
        [DataMember]
        public string ItemDescription { get; set; }
        [DataMember]
        public int RatingPrice { get; set; }
        [DataMember]
        public int BidPrice { get; set; }
        [DataMember]
        public string BidCustomerName { get; set; }
        [DataMember]
        public string BidCustomerPhone { get; set; }
        [DataMember]
        public DateTime BidTimestamp { get; set; }
    }
}